# ASE_Assignment
A repository for the assignment for the COMP611 Advanced Software Engineering module, taught at Leeds Beckett University.

# Description
The assignment is to produce a Windows Form App, written in C#, that is capable of executing a 'program' to output graphics on a canvas.

## Features
### Command Parser
- [ ] Command line for single command execution
- [ ] Program input area for multiline command execution
- [ ] Save and load program to text file
- [ ] Syntax checking
  - [ ] Check for valid commands
  - [ ] Check for valid parameters
### Drawing Commands
- [ ] Pen positioning
- [ ] Pen draw, from point A to point B
- [ ] Clear command - clear drawing area
- [ ] Reset command - reset pen position
- [ ] Basic Shapes
  - [ ] rectangle <width> <height>
  - [ ] circle <radius>
  - [ ] triangle <x1> <y1> <x2> <y2> <x3> <y3>
- [ ] pen <colour> - red, green, orange, blue
- [ ] fill <on/off> - shape fill
### Programming Commands
- [ ] Variables
- [ ] Iteration - Loop
- [ ] Selection - 'if statement'
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
