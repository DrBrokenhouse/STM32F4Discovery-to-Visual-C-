#include "stm32f4xx_it.h"
#include "stm32f4xx_conf.h"
#include "stm32f4xx_usart.h"

/**
  * @brief   This function handles NMI exception.
  * @param  None
  * @retval None
  */
__attribute__((weak)) void NMI_Handler(void)
{
}

/**
  * @brief  This function handles Hard Fault exception.
  * @param  None
  * @retval None
  */
__attribute__((weak)) void HardFault_Handler(void)
{
  /* Go to infinite loop when Hard Fault exception occurs */
  while (1)
  {
  }
}

/**
  * @brief  This function handles Memory Manage exception.
  * @param  None
  * @retval None
  */
__attribute__((weak)) void MemManage_Handler(void)
{
  /* Go to infinite loop when Memory Manage exception occurs */
  while (1)
  {
  }
}

/**
  * @brief  This function handles Bus Fault exception.
  * @param  None
  * @retval None
  */
__attribute__((weak)) void BusFault_Handler(void)
{
  /* Go to infinite loop when Bus Fault exception occurs */
  while (1)
  {
  }
}

/**
  * @brief  This function handles Usage Fault exception.
  * @param  None
  * @retval None
  */
__attribute__((weak)) void UsageFault_Handler(void)
{
  /* Go to infinite loop when Usage Fault exception occurs */
  while (1)
  {
  }
}

/**
  * @brief  This function handles SVCall exception.
  * @param  None
  * @retval None
  */
__attribute__((weak)) void SVC_Handler(void)
{
}

/**
  * @brief  This function handles Debug Monitor exception.
  * @param  None
  * @retval None
  */
__attribute__((weak)) void DebugMon_Handler(void)
{
}

/**
  * @brief  This function handles PendSVC exception.
  * @param  None
  * @retval None
  */
__attribute__((weak)) void PendSV_Handler(void)
{
}

/**
  * @brief  This function handles SysTick Handler.
  * @param  None
  * @retval None
  */
__attribute__((weak)) void SysTick_Handler(void)
{

}


volatile char received_str[];
extern void USART_puts(USART_TypeDef *USARTx, volatile char *str);
extern void VSData(char CommandLED[]);

void UART4_IRQHandler(void)
{
	char CommandLED[];
	static int cnt = 0;


	if( USART_GetITStatus(UART4, USART_IT_RXNE))// Check the Interrupt status to ensure the Rx interrupt was triggered, not Tx
	{
		char ch = UART4->DR;// Get the byte that was transferred
     	if(ch != '\n') //looks for new line, enter key press
		{


     		received_str[cnt] = ch; // builds string
			cnt++;

		}
		else
		{
			received_str[cnt] = '\0'; // looks for end of string
			cnt = 0;//once end of string is detected cnt set to 0
			USART_puts(UART4, received_str); //echos to terminal
			VSData(CommandLED) = received_str;
		}

	}
}

