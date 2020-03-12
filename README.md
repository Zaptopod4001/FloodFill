# Non-recursive flood fill (Unity / C#)

![Flood fill animation](/doc/flood_fill.gif)

## What is it?

I created this flood fill algorithm implementation as a learning experience. I didn't use any existing solutions as an example. I only set one requirement for this project - the algorithm shouldn't be using recursion. As this implementation doesn't use recursion there should be no possibility for a stack overflow while the program is executing.

There is a demo scene and a class that shows how to use this implementation of flood fill algorithm. Demo class uses flood fill algorithm for a paint bucket effect, similar to one that can be found in many 80s painting or drawing software. Despite of this, the algorithm can be used for many other purposes, like to isolate a blob of specific kind of cells or to find a connected area of map.

# Classes

## MapMaker.cs
A demo class that shows how FloodFill.cs class can be used. In this case, the algorithm execution is slowed down, and texture pixels are colored to show how algorithm works.

## FloodFill
The flood fill algorithm, in this case it only operates with integer data, but it could be changed to a more generic form.

## Copyright 
Created by Sami S. use of any kind without a written permission from the author is not allowed. But feel free to take a look.
