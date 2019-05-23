/******************************************************************************
  * @file    usart2.c
  * @author  陆展
  * @version V1.0
  * @date    2019-4-24
  * @brief   串口2相关代码 JY901用
	* @attention 调用USART2_Init(9600);完成初始化
*******************************************************************************/
 
#include "usart2.h"
#include "JY901.h"

/**************************************************************
 *@brief	USART2的GPIO与工作模式配置
 *@param	
 *@retval
 *@addition	
**************************************************************/
void USART2_Init(int baudrate)
{
  GPIO_InitTypeDef GPIO_InitStructure;
  USART_InitTypeDef USART_InitStructure;
	NVIC_InitTypeDef NVIC_InitStructure; 
	
	//相关时钟使能
	USART2_RCC_ENABLE;
	
  //GPIO初始化
  GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
  GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;  
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
  
  //配置Tx引脚为复用功能
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
  GPIO_InitStructure.GPIO_Pin =  USART2_TX_PIN  ;  
  GPIO_Init(USART2_TX_GPIO_PORT, &GPIO_InitStructure);

  //配置Rx引脚为复用功能
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
  GPIO_InitStructure.GPIO_Pin =  USART2_RX_PIN;
  GPIO_Init(USART2_RX_GPIO_PORT, &GPIO_InitStructure);

  //连接 PXx 到 USARTx_Tx
  GPIO_PinAFConfig(USART2_TX_GPIO_PORT,USART2_TX_SOURCE,USART2_TX_AF);
  
	//连接 PXx 到 USARTx_Rx
  GPIO_PinAFConfig(USART2_RX_GPIO_PORT,USART2_RX_SOURCE,USART2_RX_AF);


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
  //USART模式控制	USART_ITConfig(DEBUG_USART, USART_IT_RXNE, ENABLE);//开启串口接受中断
  USART_InitStructure.USART_Mode = USART_Mode_Rx | USART_Mode_Tx;
  //完成USART初始化配置
  USART_Init(USART2, &USART_InitStructure);
	//开启串口接受中断
	USART_ITConfig(USART2, USART_IT_RXNE, ENABLE);	
  //使能串口
  USART_Cmd(USART2, ENABLE);
	
	//中断配置
	NVIC_InitStructure.NVIC_IRQChannel = USART2_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority=2 ;//抢占优先级2
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 2;		//子优先级2
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;			//IRQ通道使能
	NVIC_Init(&NVIC_InitStructure);	//根据指定的参数初始化VIC寄存器
}



/***************************************************************
 *@brief USART2 中断处理函数
 *@param
 *@retval
 *@addition
****************************************************************/

void USART2_IRQHandler(void)
{
	if(USART_GetITStatus(USART2, USART_IT_RXNE) != RESET)
  {
		JY901_DataReceive((uint8_t)USART_ReceiveData(USART2));//处理数据
		USART_ClearITPendingBit(USART2, USART_IT_RXNE);
  }
}



