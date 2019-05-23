/******************************************************************************
  * @file    USART1.c
  * @author  陆展
  * @version V1.0
  * @date    2019-4-24
  * @brief   串口3相关代码
	* @attention 调用USART1_Init(115200);完成初始化
*******************************************************************************/
 
#include "USART1.h"
#include "datapocket.h"

/**************************************************************
 *@brief	USART1的GPIO与工作模式配置
 *@param	
 *@retval
 *@addition	
**************************************************************/
void USART1_Init(int baudrate)
{
  GPIO_InitTypeDef GPIO_InitStructure;
  USART_InitTypeDef USART_InitStructure;
	NVIC_InitTypeDef NVIC_InitStructure; 
	
	//相关时钟使能
	USART1_RCC_ENABLE;
	
  //GPIO初始化
  GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
  GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;  
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
  
  //配置Tx引脚为复用功能
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
  GPIO_InitStructure.GPIO_Pin =  USART1_TX_PIN  ;  
  GPIO_Init(USART1_TX_GPIO_PORT, &GPIO_InitStructure);

  //配置Rx引脚为复用功能
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
  GPIO_InitStructure.GPIO_Pin =  USART1_RX_PIN;
  GPIO_Init(USART1_RX_GPIO_PORT, &GPIO_InitStructure);

  //连接 PXx 到 USARTx_Tx
  GPIO_PinAFConfig(USART1_TX_GPIO_PORT,USART1_TX_SOURCE,USART1_TX_AF);
  
	//连接 PXx 到 USARTx_Rx
  GPIO_PinAFConfig(USART1_RX_GPIO_PORT,USART1_RX_SOURCE,USART1_RX_AF);


  //工作模式配置
  //波特率设置
  USART_InitStructure.USART_BaudRate = baudrate;
  //字长(数据位+校验位)
  USART_InitStructure.USART_WordLength = USART_WordLength_8b;	
  //停止位
  USART_InitStructure.USART_StopBits = USART_StopBits_1;
  //校验位选择
	USART_InitStructure.USART_Parity = USART_Parity_No;
  //硬件流控制
  USART_InitStructure.USART_HardwareFlowControl = USART_HardwareFlowControl_None;
  //USART模式控制	
  USART_InitStructure.USART_Mode = USART_Mode_Rx | USART_Mode_Tx;
  //完成USART初始化配置
  USART_Init(USART1, &USART_InitStructure);
	//开启串口接受中断
	USART_ITConfig(USART1, USART_IT_RXNE, ENABLE);	
  //使能串口
  USART_Cmd(USART1, ENABLE);
	
	//中断配置
	NVIC_InitStructure.NVIC_IRQChannel = USART1_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority=3 ;//抢占优先级3
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 3;		//子优先级3
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;			//IRQ通道使能
	NVIC_Init(&NVIC_InitStructure);	//根据指定的参数初始化VIC寄存器
}


/****************************************************************
 *@brief 输出一个字符
 *@param DataToSend：要发送的字符
 *@retval
 *@addition
*****************************************************************/
void USART1_PutChar(char ch)
{
	USART_SendData(USART1, (unsigned char) ch);
	while (!(USART1->SR & USART_FLAG_TXE));
}


/***************************************************************
 *@brief USART1 中断处理函数
 *@param
 *@retval
 *@addition
****************************************************************/
void USART1_IRQHandler(void)
{
	if(USART_GetITStatus(USART1, USART_IT_RXNE) != RESET)
  {
		Command_ReceiveAndCheck(USART_ReceiveData(USART1));	//串口1接收到上位机发来的控制指令 			
		USART_ClearITPendingBit(USART1, USART_IT_RXNE);
  }
	USART_ClearITPendingBit(USART1,USART_IT_ORE);
}

/**************************************************************
 *@brief	重定向c库函数printf到串口
 *@param	
 *@retval
 *@addition	重定向后可使用printf函数
**************************************************************/
int fputc(int ch, FILE *f)
{
	//发送一个字节数据到串口
	USART_SendData(USART1, (uint8_t) ch);
		
	//等待发送完毕
	while (USART_GetFlagStatus(USART1, USART_FLAG_TXE) == RESET);		
	
	return (ch);
}
/**************************************************************
 *@brief	重定向c库函数scanf到串口
 *@param	
 *@retval
 *@addition	重写向后可使用scanf、getchar等函数
**************************************************************/
int fgetc(FILE *f)
{
		//等待串口输入数据
		while (USART_GetFlagStatus(USART1, USART_FLAG_RXNE) == RESET);

		return (int)USART_ReceiveData(USART1);
}
