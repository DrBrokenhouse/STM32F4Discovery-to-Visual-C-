/*
	Robert Thomas
	thomasrl@sbcglobla.net

	Version History
	version 1.0 Communication through hyper terminal
	Version 2.0 Communication through Visual Studio C#
	Version 3.0 Interrupt used to echo serial back to Visual Studio C#
	----------------------------------------------------------
	Special notes:
		stm32f4xx.h file line 92
			Change the HSE_VALUE value to ((uint32_t)8000000)
		GPIOB pin 1 is used for positive for buzzer
		GPIOC pin 10 UART4 Tx
		GPIOC pin 11 UART4 Rx
		UART4 is used for this program
		USB serial board PL2303
	-----------------------------------------------------------
	Communication setup
		Baud Rate = 9600
		Data bits = 8
		Stop Bits = 1
		Parity= None
		Flow Control = None
		Com3 for my computer, but could change with yours.
	------------------------------------------------------------
	Communication protocol
		serial number		        Task
		-----------------------------------------
			22201...............Blink All LEDs
			22202...............Pinwheels LEDs
			22203...............Sounds the buzzer
			22204...............All LEDs on
			22205...............All LEDs off
			22206...............Green LED on
			22207...............Green LED off
			22208...............Amber LED on
			22209...............Amber LED off
			22210...............Red LED on
			22211...............Red LED off
			22212...............Blue LED ON
			22213...............Blue LED off
			22214...............Self Test
*/
//**********************Libraries*******************************
#include <misc.h>
#include "stdio.h"
#include "stdlib.h"
#include <stm32f4xx.h>
#include <stm32F4xx_it.h>
#include <stm32f4xx_rcc.h>
#include <stm32f4xx_gpio.h>
#include <stm32f4xx_conf.h>
#include <stm32f4xx_usart.h>

//********************** Prototype functions ************************

void setup_Periph(void);
void SysTick_Handler(void);
void LED_Status_Reset(void);
static void Delay(uint32_t dlyTicks);
void USART_puts(USART_TypeDef *USARTx, volatile char *str);
void SelfTest(void);

//********************** Process type functions ************************
//********************** Time setup *************************************
volatile uint32_t msTicks; // Counts 1ms timeTicks

void SysTick_Handler (void)
{
  msTicks++;                                    // increment Delay()-counter
}

//********************** Delay setup **********************************

static void Delay (uint32_t dlyTicks)
{
	  uint32_t curTicks;

  SysTick_Config(48000000/10000); // we're operating at 48 MHz
  curTicks = msTicks;
  while ((msTicks - curTicks) < dlyTicks); // wait here until our time has come...
}

//********************** print to serial ************************

//Pass in any USART; 1,2,3 and so on. the pass in string
void USART_puts(USART_TypeDef *USARTx, volatile char *str)
{
	while(*str)
	{
		while(USART_GetFlagStatus(UART4, USART_FLAG_TC) == RESET);
		USART_SendData(USARTx, *str);
		*str++;
	}
}

//********************** STM32F peripheral setup ************************
void setup_Periph(void)
{
	GPIO_InitTypeDef GPIO_InitStructure; //Port initialization
	USART_InitTypeDef USART_InitStructure; //USART initialization
	NVIC_InitTypeDef NVIC_InitStructure; //Interrupt initialization

	//Enable the GPIOC clock for UART4
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_UART4, ENABLE);

	//Enable the GPIOA clock for serial communication
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA, ENABLE);

	//Enable the GPIOB clock for buzzer
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOB, ENABLE);

	//Enable the GPIOC clock for serial communication
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOC, ENABLE);

	//Enable the GPIOC clock for LEDs
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD, ENABLE);

	//Setup for GPIOD pins for LEDS
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_12 | GPIO_Pin_13 | GPIO_Pin_14 | GPIO_Pin_15;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
	GPIO_Init(GPIOD, &GPIO_InitStructure);

	//Setup for GPIOB pin for buzzer
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_1;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_DOWN;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOB, &GPIO_InitStructure);


	//Setup for GPIOC pins for serial communication
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_10 | GPIO_Pin_11;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_UP;
	GPIO_Init(GPIOC, &GPIO_InitStructure);

	//Assign GPIOC pins to UART4 alternate functions
	GPIO_PinAFConfig(GPIOC, GPIO_PinSource10, GPIO_AF_UART4);/* UART4_TX */
	GPIO_PinAFConfig(GPIOC, GPIO_PinSource11, GPIO_AF_UART4);/* UART4_RX */

	//serial communication controls
	USART_InitStructure.USART_BaudRate = 9600;
	USART_InitStructure.USART_WordLength = USART_WordLength_8b;
	USART_InitStructure.USART_StopBits = USART_StopBits_1;
	USART_InitStructure.USART_Parity = USART_Parity_No;
	USART_InitStructure.USART_HardwareFlowControl = USART_HardwareFlowControl_None;
	USART_InitStructure.USART_Mode = USART_Mode_Tx | USART_Mode_Rx;
	USART_Init(UART4, &USART_InitStructure);

	//UART4_IRQHandler() interrupt and configure
	USART_ITConfig(UART4, USART_IT_RXNE, ENABLE);

	NVIC_InitStructure.NVIC_IRQChannel = UART4_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
	NVIC_Init(&NVIC_InitStructure);

	// Finally enable the UART4 peripheral
	USART_Cmd(UART4, ENABLE);
}

//************* global variables for program ******************

extern int LED_Flag;
extern char VS_Data[];
extern int LED_Command;

//********************* main() ********************************
int main(void)
{

//********************* main() required functions ***************

	setup_Periph(); // initialize functionality

//********************* main() variable declaration ****************




//********************* main() Program *****************************
		SelfTest();
		USART_puts(UART4, "\rSTM32F4 Discovery Board.\n");
		Delay(5);
		USART_puts(UART4, "ver: 3.1 Date: 01/31/2015.\n");
		Delay(5);
		USART_puts(UART4, "Programmed by Robert Thomas.\n");

		LED_Flag = 0;

	 while(1)
	{

		 //read data from terminal
		while(USART_GetFlagStatus(UART4, USART_FLAG_RXNE)==RESET); //Receive data register not empty flag

		while(LED_Flag = 1) //this flag is set in UART4_IRQHandler()
		{
			//This is the serial number passed from Visual Studio C# button press
			if((LED_Command >= 22201) || (LED_Command <= 22214))
			{

				switch(LED_Command) //Check for what number was passed
				{

				case 22201:// Blink on ALL Led

					USART_puts(UART4, "\nBlink all LEDs."); // prints to terminal
					AllBlink(25,500,75); //number of blinks, time on, time off
					beep(3,500,75);
					LED_Status_Reset();

				break;

				case 22202:  // Pinwheel on ALL Led

					USART_puts(UART4, "Pinwheel the LEDs."); // prints to terminal
					pinwheel();
					LED_Status_Reset();

				break;

				case 22203: // Sound alarm

					USART_puts(UART4, "Alarm sounding.\n"); // prints to terminal
					alarm();
					LED_Status_Reset();

				break;

				case 22204: // Turn on ALL Led

					GPIO_SetBits(GPIOD, GPIO_Pin_All);
					USART_puts(UART4, "All LEDs on.\n"); // prints to terminal
					beep(1,500,75);
					LED_Status_Reset();

				break;

				case 22205: // Turn off ALL Led

					GPIO_ResetBits(GPIOD, GPIO_Pin_All);
					USART_puts(UART4, "All LEDs off.\n"); // prints to terminal
					LED_Status_Reset();

				break;

				case 22206: // Turns on the green LED

					GPIO_SetBits(GPIOD, GPIO_Pin_12);
					USART_puts(UART4, "Green LED on.\n"); // prints to terminal
					beep(1,500,75); // 1 loop, 500ms on with 75ms delay off
					LED_Status_Reset();

				break;

				case 22207: // Turns off green Led

					GPIO_ResetBits(GPIOD, GPIO_Pin_12);
					USART_puts(UART4, "Green LED off.\n"); // prints to terminal
					LED_Status_Reset();

				break;

				case 22208: // Turn on amber Led

					GPIO_SetBits(GPIOD, GPIO_Pin_13);
					USART_puts(UART4, "Amber LED on.\n"); // prints to terminal
					beep(1,500,75);  // 1 loop, 500ms on with 75ms delay off
					LED_Status_Reset();

				break;

				case 22209: // Turn off amber Led

					GPIO_ResetBits(GPIOD, GPIO_Pin_13);
					USART_puts(UART4, "Amber LED off.\n"); // prints to terminal
					LED_Status_Reset();

				break;

				case 22210:// Turn on red Led

					GPIO_SetBits(GPIOD, GPIO_Pin_14);
					USART_puts(UART4, "Red LED on.\n"); // prints to terminal
					beep(1,500,75); // 1 loop, 500ms on with 75ms delay off
					LED_Status_Reset();

				break;

				case 22211: // Turn off red Led

					GPIO_ResetBits(GPIOD, GPIO_Pin_14);
					USART_puts(UART4, "Red LED off.\n"); // prints to terminal
					LED_Status_Reset();


				break;

				case 22212:// Turn on blue Led

					GPIO_SetBits(GPIOD, GPIO_Pin_15);
					USART_puts(UART4, "Blue LED on.\n"); // prints to terminal
					beep(1,500,75);  // 1 loop, 500ms on with 75ms delay off
					LED_Status_Reset();

				break;

				case 22213:// Turn off blue Led

					GPIO_ResetBits(GPIOD, GPIO_Pin_15);
					USART_puts(UART4, "Blue LED off.\n"); // prints to terminal
					LED_Status_Reset();

				break;

				case 22214:// Test the boards serial communication

					SelfTest();

				break;
				}
			}
		}
	}
}

//********************* SelfTest() ********************************

void SelfTest(void)
{
	int rounds = 10; //sets toggle of on's and off's
	USART_puts(UART4, "\rBoard self test. Please wait.");
	while(rounds)
	{
		USART_puts(UART4, ".");
		// LEDs on
		GPIO_SetBits(GPIOD, GPIO_Pin_12 | GPIO_Pin_13 | GPIO_Pin_14 | GPIO_Pin_15);
		beep(1,100,75);  // 1 loop, 100ms on with 75ms delay off
		Delay(150);// set to 150ms
		//LEDs off
		GPIO_ResetBits(GPIOD, GPIO_Pin_12 | GPIO_Pin_13 | GPIO_Pin_14 | GPIO_Pin_15);
		Delay(150);// set to 1500ms
		rounds--;
	}
	USART_puts(UART4, "\n");
	LED_Status_Reset();
	USART_puts(UART4, "Test compete.");

}

//********************* LED_Status_Reset() ********************************

void LED_Status_Reset(void)
{
	LED_Flag = 0; //reset the flag status so the loop will stop
	LED_Command = 0; //resets the serial number from Visual Studio C#
}

//********************* pinwheel() ********************************

void pinwheel(void)
{
	int round = 75; //This sets the number of revolutions and the speed.
	while(round)
	{
		USART_puts(UART4, ".");
		GPIO_SetBits(GPIOD, GPIO_Pin_12);
		Delay(round);
		GPIO_ResetBits(GPIOD, GPIO_Pin_12);
		Delay(round);
		GPIO_SetBits(GPIOD, GPIO_Pin_13);
		Delay(round);
		GPIO_ResetBits(GPIOD, GPIO_Pin_13);
		Delay(round);
		GPIO_SetBits(GPIOD, GPIO_Pin_14);
		Delay(round);
		GPIO_ResetBits(GPIOD, GPIO_Pin_14);
		Delay(round);
		GPIO_SetBits(GPIOD, GPIO_Pin_15);
		Delay(round);
		GPIO_ResetBits(GPIOD, GPIO_Pin_15);
		Delay(round);
		round--;
	}
	USART_puts(UART4, "\n");
}

//********************* AllBlink() ********************************

void AllBlink(int rounds, int time_on, int time_off)
{
	//int blink = 25; //sets toggle of on's and off's


	while(rounds)
	{
		USART_puts(UART4, ".");
		// LEDs on
		GPIO_SetBits(GPIOD, GPIO_Pin_12 | GPIO_Pin_13 | GPIO_Pin_14 | GPIO_Pin_15);
		Delay(time_on);// set to 250ms
		//LEDs off
		GPIO_ResetBits(GPIOD, GPIO_Pin_12 | GPIO_Pin_13 | GPIO_Pin_14 | GPIO_Pin_15);
		Delay(time_off);// set to 250ms
		rounds--;
	}
	USART_puts(UART4, "\n");
}

//********************* Beep() ********************************

//sets the number off beeps and the on time and the off time
void beep(int rounds, int time_on, int time_off)
{
	while(rounds)//rounds = number of loops
	{
		GPIO_SetBits(GPIOB, GPIO_Pin_1); //buzzer on
		Delay(time_on);//time_on = ms on
		GPIO_ResetBits(GPIOB, GPIO_Pin_1); // buzzer off
		Delay(time_off);//time_off = ms off
		rounds--;
	}
}

//********************* Alarm() ********************************

void alarm(void)
{
	//plays the tune, "shave and a hair cut, 2 bits."
	//BEAT 1
	GPIO_SetBits(GPIOB, GPIO_Pin_1); //buzzer on
	GPIO_SetBits(GPIOD, GPIO_Pin_15); // Blue LED on
	USART_puts(UART4, "* ");
	Delay(675);
	GPIO_ResetBits(GPIOD, GPIO_Pin_15); // Blue LED off
	GPIO_ResetBits(GPIOB, GPIO_Pin_1); //buzzer off
	Delay(225);

	//BEAT 2
	GPIO_SetBits(GPIOB, GPIO_Pin_1);  //buzzer on
	GPIO_SetBits(GPIOD, GPIO_Pin_15);  // Blue LED on
	USART_puts(UART4, "* ");
	Delay(507);
	GPIO_ResetBits(GPIOD, GPIO_Pin_15); // Blue LED off
	GPIO_ResetBits(GPIOB, GPIO_Pin_1); //buzzer off
	Delay(170);

	//BEAT 3
	GPIO_SetBits(GPIOB, GPIO_Pin_1); //buzzer on
	GPIO_SetBits(GPIOD, GPIO_Pin_15); // Blue LED on
	USART_puts(UART4, "* ");
	Delay(170);
	GPIO_ResetBits(GPIOD, GPIO_Pin_15); // Blue LED off
	GPIO_ResetBits(GPIOB, GPIO_Pin_1); //buzzer off
	Delay(57);

	//BEAT 4
	GPIO_SetBits(GPIOB, GPIO_Pin_1); //buzzer on
	GPIO_SetBits(GPIOD, GPIO_Pin_15); // Blue LED on
	USART_puts(UART4, "* ");
	Delay(675);
	GPIO_ResetBits(GPIOD, GPIO_Pin_15); // Blue LED off
	GPIO_ResetBits(GPIOB, GPIO_Pin_1); //buzzer off
	Delay(225);

	//BEAT 5
	GPIO_SetBits(GPIOB, GPIO_Pin_1); //buzzer on
	GPIO_SetBits(GPIOD, GPIO_Pin_15); // Blue LED on
	USART_puts(UART4, "* ");
	Delay(675);
	GPIO_ResetBits(GPIOD, GPIO_Pin_15); // Blue LED off
	GPIO_ResetBits(GPIOB, GPIO_Pin_1); //buzzer off
	Delay(1125);

	//BEAT 6
	GPIO_SetBits(GPIOB, GPIO_Pin_1); //buzzer on
	GPIO_SetBits(GPIOD, GPIO_Pin_14); // Red LED on
	USART_puts(UART4, "* ");
	Delay(675);
	GPIO_ResetBits(GPIOD, GPIO_Pin_14); // Red LED off
	GPIO_ResetBits(GPIOB, GPIO_Pin_1); //buzzer off
	Delay(225);

	 //BEAT 7
	GPIO_SetBits(GPIOB, GPIO_Pin_1); //buzzer on
	GPIO_SetBits(GPIOD, GPIO_Pin_12); // Green LED on
	USART_puts(UART4, "* ");
	Delay(675);
	GPIO_ResetBits(GPIOD, GPIO_Pin_12); // Green LED of
	GPIO_ResetBits(GPIOB, GPIO_Pin_1); //buzzer off
	Delay(225);
	USART_puts(UART4, "\n");
}





