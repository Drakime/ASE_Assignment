# ASE_Assignment
A repository for the assignment for the COMP611 Advanced Software Engineering module, taught at Leeds Beckett University.

# Description
The assignment is to produce a Windows Form App, written in C#, that is capable of executing a 'program' to output graphics on a canvas.

## Features
### Command Parser
- [x] Command line for single command execution
- [x] Program input area for multiline command execution
- [x] Save and load program to text file
- [x] Syntax checking
  - [x] Check for valid commands
  - [x] Check for valid parameters
### Drawing Commands
- [x] Pen positioning
- [x] Pen draw, from point A to point B
- [x] Clear command - clear drawing area
- [x] Reset command - reset pen position
- [x] Basic Shapes
  - [x] rectangle <width> <height>
  - [x] circle <radius>
  - [x] triangle <x1> <y1> <x2> <y2> <x3> <y3>
- [x] pen <colour> - black, red, green, orange, blue
- [x] fill <on/off> - shape fill
### Programming Commands
- [x] Variables
- [x] Iteration - Loop
- [x] Selection - 'if statement'
- [ ] Syntax check before program run
- [ ] Methods
  - Define method with:
  ```
  Method myMethod(parameter list)
    Line 1
    Etc
  Endmethod
  ```
  - End method with:
  ```
  myMethod(<parameter list>)
  ```
- [ ] Flashing colours using threads
