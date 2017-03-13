## zumuverifier
#Mainarizumu Verifier

This is a tool designed to assist with the iterative development 
of [Mainarizumu](https://en.wikipedia.org/wiki/Mainarizumu/) puzzles.
The software uses a simple input format and the output is compatible 
with another run, allowing incomplete puzzles to be edited and then 
the process will continue without running the earlier analysis again.

#Running the solution

The project builds in the output folder of the Zumu windows command line 
project a command line tool that is called as `zumu <path to input>` and
will output to standard output the solution or how far the Verifier could get.
This can be output to a file using standard output redirection (`zumu filename >outfilename`).

The `zumu.exe` executable can be moved anywhere as it has no dependencies on the project,
only on DotNet4.5.2.

There is also a unit test project that contains examples of solving various size
puzzles which can be used directly in Visual Studio.

The solution is compatible with the Community Edition of Visual Studio 2015. 
The string consumed when constructing a new Mainarizumu class uses a comma separated
file format described below.

#File Format

The final format is still being discussed, but the current format is a comma separated
file as shown in the 2x2 example below:

```
2
,>,
v,,
,,
```

The first line states the size of the puzzle. Then there is a line
which will have value/clue pairs except for the last value has no clue
that follows it. In our example, we have an unknown value with a greater than
clue and another unknown value. Legal clues are ">", "<" or a number up to 
the size of the puzzle, minus one. 

Alternating lines are then the clues between the rows. No values are present
but to keep the shape of the file readable in a CSV compatible file reader, we
have clue/dummy pairs, where the clues are "v", "^" or a number up to the size
of the puzzle, minus one.

The output is the same form, but there will be additional known values such as the 
output from the above puzzle: 

```
2
2,>,1
v,,
1,,2
```




