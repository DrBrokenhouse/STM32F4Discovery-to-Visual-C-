#include "stm32f4xx_it.h"
#include "stm32f4xx_conf.h"
#include <stm32f4xx_usart.h>
#include "stdlib.h"

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


#define MAX_WORDLEN 10
char DATA[MAX_WORDLEN + 1];
extern void USART_puts(USART_TypeDef *USARTx, volatile char *str);
int cnt = 0;
int LED_Flag; // When this flag is 1, the serial data is ready to be read.
char VS_Data[];
int LED_Command;

// UART4 Interrupt request handler for ALL (Tx/Rx) UART4 interrupts
void UART4_IRQHandler(void)
{
	LED_Flag = 0; // This will 0 the flag at start up.
	// Check the Interrupt status to ensure the Rx interrupt was triggered, not Tx
	if(USART_GetITStatus(UART4, USART_IT_RXNE))
	{

		// Get the byte that was transferred
		int ch = UART4->DR;// data coming from Visual Studio C# (this part works)

		// Check for "Enter" key, or Maximum characters
		if(ch != '\n')
		{
			DATA[cnt++] = ch;// building the string

		}
		else
		{
			DATA[cnt] = '\0';
			cnt = 0; // setting cnt to 0 after the \0 is reached.
			if(USART_GetITStatus(UART4, USART_IT_TC) == RESET)
			{
				LED_Flag = 1; // Flag set data is read to send to board
				strncpy(VS_Data, DATA, sizeof DATA);
				LED_Command = atoi(VS_Data);
				//USART_puts(UART4, VS_Data); // echo
			}


		}


	}
}










