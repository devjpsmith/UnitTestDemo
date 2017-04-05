## UnitTestDemo ##

## Overview ##

This is a vary simple application that does nothing except demonstrate some
concepts about unit testing. 

The main application, UnitTestDemo, is a .NET
console application that demonstrates how write code using dependency injection
in order to isolate the functionality of objects in a way that allows them to
be put through automated testing tools.

The UnitTestDemo.nUnit project is a .NET class library that contains the 
automated tests. Each class that contains methods run by the testing tool 
injects stub, or mock, classes into the objects that require them. This allows
the code inside those classes to be tested with known sets of data. The code
in these classes being tested is also tested in isolation from the actual
implementations that it depends on - in other words, you can test your 
business logic without depending on the database code to behave as expected.
This allows easier debugging when something goes wrong.

## Required Tools ##

The UnitTestDemo.nUnit project requires the [NUnit NuGet package](https://www.nuget.org/packages/NUnit/).

To run the nUnit tests, I recommend installing the [NUnit Test Adapter](https://www.nuget.org/packages/NUnit3TestAdapter/) in Visual Studio

To use the Test Adapter, you will want to open 
Test -> Windows -> Test Explorer.
There will be no tests at first in the Test Explorer. Once you compile the
projects, the tests should appear. You can just hit __Run All__ to execute the
tests.
