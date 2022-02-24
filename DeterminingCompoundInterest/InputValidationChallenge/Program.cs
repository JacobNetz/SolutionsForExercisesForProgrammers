using InputValidationChallenge;
using Spectre.Console.Cli;

// This version of the exercise solution accepts command line arguments
// instead of prompting for values once the app is running.
// For example: 
/*
> .\InputValidationChallenge.exe -h
USAGE:
    InputValidationChallenge.dll <Principal> <InterestRate> <Years> <CompoundsPerYear> [OPTIONS]

ARGUMENTS:
    <Principal>
    <InterestRate>
    <Years>
    <CompoundsPerYear>

OPTIONS:
    -h, --help    Prints help information

> InputValidationChallenge.exe 1500 4.3 6 4
$1,500.00 invested at 4.30% for 6 year(s) compounded 4 times per year is $1,938.84.
*/

/****** Uncomment following two lines to run calculation based off CLI parameters ******/
//var app = new CommandApp<InterestCommand>();
//return app.Run(args);

new ChallengeSolutionAlternative().CalculateInterest();