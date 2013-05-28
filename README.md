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

 
END - no paremeters         - Ends program <br>
ADD - 3 registers          - Addition <br>
SUB - 3 registers          - Subtraction <br>
MUL - 3 registers          - Multiplication <br>
DIV - 3 registers          - Division <br>
MOD - 3 registers          - Modulus <br>
AND - 3 registers          - Binary AND <br>
ORO - 3 registers          - Binary OR <br>
NOT - 3 registers          - Binary NOT <br>
SLT - 3 registers          - If less than <br>
SGT - 3 registers          - If bigger than <br>
SEQ - 3 registers          - If equal <br>
CPY - 2 registers          - Copy <br>
JMP - 1 label              - Jump <br>
JPZ - 1 register + 1 label - Jump if zero <br>
JNZ - 1 register + 1 label - Jump if not zero <br>
LOD - 2 registers          - Read from RAM <br>
STO - 2 registers          - Write to RAM <br>
IMM - 1 register + 1 value - Load value <br>
CAL - 1 label              - Call subroutine <br>
RET - no parameters        - Return from subroutine <br>
PSH - 1 register           - Push stack <br>
POP - 1 register           - Pop stack <br>
INC - 1 register           - Increase by one <br>
DEC - 1 register           - Decrease by one <br>
NOP - no registers         - No operation <br>

Registers
=============
R0 - R7 <br>
SP - Stack top address <br>
PC - Address to next instruction in program <br>
IR - Contains the previously run command <br>
IO - If IO is an operand, user will be asked to input a number <br>
RL - Unknown <br>
TP - Unknown <br>
