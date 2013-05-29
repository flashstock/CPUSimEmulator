CPUSim
=============
Emulator for CPUSim

License
=============
Copyright (c) 2013 Johan Hugg

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

Examples
=============
![ScreenShot](https://dl.dropboxusercontent.com/u/12347804/sharex/2013-05-28_14-03-16.png)

Command List
=============
Command - target operand operand


|OP           |Parameters            |Description            |
|:------------|:---------------------|:----------------------|
|END          |No paremeters         |Ends program           |
|ADD          |3 registers           |Addition               |
|SUB          |3 registers           |Subtraction            |
|MUL          |3 registers           |Multiplication         |
|DIV          |3 registers           |Division               | 
|MOD          |3 registers           |Modulus                |
|AND          |3 registers           |Binary AND             | 
|ORO          |3 registers           |Binary OR              |
|NOT          |3 registers           |Binary NOT             |
|SLT          |3 registers           |If less than           |
|SGT          |3 registers           |If bigger than         |
|SEQ          |3 registers           |If equal               |
|CPY          |2 registers           |Copy                   |
|JMP          |1 label               |Jump                   |
|JPZ          |1 register + 1 label  |Jump if zero           |
|JNZ          |1 register + 1 label  |Jump if not zero       |
|LOD          |2 registers           |Read from RAM          |
|STO          |2 registers           |Write to RAM           |
|IMM          |1 register + 1 value  |Load value             |
|CAL          |1 label               |Call subroutine        |
|RET          |No parameters         |Return from subroutine |
|PSH          |1 register            |Push stack             |
|POP          |1 register            |Pop stack              |
|INC          |1 register            |Increase by one        |
|DEC          |1 register            |Decrease by one        |
|NOP          |No registers          |No operation           |

Registers
=============
R0 - R7 <br>
SP - Stack top address <br>
PC - Address to next instruction in program <br>
IR - Contains the previously run command <br>
IO - If IO is an operand, user will be asked to input a number <br>
RL - Unknown <br>
TP - Unknown <br>
