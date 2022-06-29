/*      arduino-box
 *        2019.
 *          by dankkaaa 
*/

//-------------------- БИБЛИОТЕКИ ------------------
#include <Servo.h> // библиотека для servo
//-------------------- БИБЛИОТЕКИ ------------------

//-------------------- НАСТРОЙКИ ------------------
// ВСЕ значения в #define можно настроить под себя
#define button A1 // кнопка открыть/закрыть 
#define servo_min 20 // минимальное значение поворота servo
#define servo_max 180 // максимальное значение поворота servo
#define pin 4 // светодиод на 4 пине
Servo servo; // присваиваем переменной servo значение Servo
int press = 0; // нажатие равно 0-ю
boolean toggle = true;  // toggle равно true(1)
unsigned long last_press;
//-------------------- НАСТРОЙКИ ------------------

void setup()
{ 
  servo.attach(A0); // подключаем servo
  pinMode(button, OUTPUT); // подключаем кнопку
  pinMode(pin, OUTPUT); // подключаем светодиод
  last_press = millis(); // по идеи, с этой строчкой всё должно работать лучше, но я не пробовал 
  }

void loop()
{
   press = digitalRead(button); 
  if (press == HIGH) // если press(button) равен HIGH(1)
  {
    if(toggle && millis() - last_press > 15) // millis - last_press - задержка (можно выбрать любую)
    {
      servo.write(servo_min); // поворот
      digitalWrite(pin, HIGH); // светодиод начинает гореть
      toggle = !toggle; // toggle = отрицательный toggle (напомню: toggle = true)
      last_press = millis(); // задержка для уменьшивание дребезка кнопки(помогает плохо)
    }
    else // в другом случае
    {
      servo.write(servo_max); // servo сделает максимальный поворот
      digitalWrite(pin,LOW); // светодиод перестанет гореть
      toggle = !toggle;
    }
  }
  delay(5); // задержка для правильной работы прошивки
}
