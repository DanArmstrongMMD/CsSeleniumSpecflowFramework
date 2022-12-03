# C# Selenium Framework using Specflow with NUnit

Basic C# Selenium Framework using Specflow, for developing automated end to end browser tests.

# What's Inside

- C# Selenium setup so you can quickly get started with writing steps
- Page Object Model structure, with a Base Page containing wrappers for some common Selenium functionality
- Parallel execution of Specflow Feature files

# Usage

Designed for use as a template for a new repository of tests, download and use as a template.

# Running the Tests
 
 In order to run these tests, you will need .NET Core installed on your machine.
 
 From a terminal, run:

```
 dotnet test
```
 
Or, if you have Visual Studio installed (with the Specflow Extension) and you can view all Scenarios and Feature files in the Test Explorer, allowing you to run these from within your IDE.

# How to Write New Tests

Using this template, you can find an example feature file in the ```Features/``` folder, and you should write new features in here too. Step files are found in ```StepDefinitions/```, alongside the Page Objects in the neighbouring ```Pages/``` directory.

# Coming Soon

- Driver Factory Class for generating the driver and browser based on command line arguments
- Screenshot on failure
- Local reporting
