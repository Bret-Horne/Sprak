using System;
using NUnit.Framework;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingLanguageNr1.tests
{
	[TestFixture()]
	public class SprakProgram_TEST
	{
        [Test()]
        public void EmptySprakRunner()
        {
            StringReader programString = new StringReader("");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
        }

        [Test()]
        public void FunctionDefinition()
        {
            StringReader programString = new StringReader("number apa(string a, string b) \n end");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
        }

        [Test()]
        public void CalculateSimple()
        {
            StringReader programString = new StringReader("5 + 3");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
        }

        [Test()]
        public void CallAnExternalFunctionWithArguments()
        {
            StringReader programString = new StringReader("print(\"test!\")");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
            Assert.AreEqual("test!", program.Output[0]);
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
        }
		
        [Test()]
        public void CallUserdefinedFunction()
        {
            StringReader programString = new StringReader("Foo()\nvoid Foo()\nend\nFoo()");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
        }

        [Test()]
        public void HelloWorld()
        {
            StringReader programString = new StringReader("print(\"Hello World!\")");

            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();

            Assert.AreEqual("Hello World!", program.Output[0]);
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
        }

        [Test()]
        public void Assignment()
        {
            StringReader programString = new StringReader("number a = 5");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
        }	
		
		[Test()]
		public void MathProblem ()
		{
			StringReader programString = new StringReader("print(5 * 2 + 3 * 4)");

            DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();
			
			Assert.AreEqual("22", program.Output[0]);
			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
		}

        [Test()]
        public void SimpleConditional()
        {
            TextReader programString = File.OpenText("code36.txt");

            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();

            Assert.AreEqual("15", program.Output[0]);
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
        }
		
		[Test()]
		public void PrintingMathExpressions ()
		{
			TextReader programString = File.OpenText("code19.txt");

            DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();
			
			Assert.AreEqual("20", program.Output[0]);
			Assert.AreEqual("-4", program.Output[1]);
			Assert.AreEqual("11", program.Output[2]);
			Assert.AreEqual("-20", program.Output[3]);
			Assert.AreEqual("-1", program.Output[4]);
			Assert.AreEqual("0.5", program.Output[5]);
			Assert.AreEqual("-0.5", program.Output[6]);
			Assert.AreEqual("100.1", program.Output[7]);
			
			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
		}
		
		[Test()]
		public void SingleVariableAssignment ()
		{
			TextReader programString = File.OpenText("code20.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();
			Assert.AreEqual("5", program.Output[0]);
			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
		}
			
		[Test()]
		public void SimpleVariableUsage ()
		{
			TextReader programString = File.OpenText("code21.txt");

            DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

            Assert.AreEqual(4, program.Output.Count);
			Assert.AreEqual("10", program.Output[0]);
			Assert.AreEqual("20", program.Output[1]);
			Assert.AreEqual("30", program.Output[2]);
			Assert.AreEqual("40", program.Output[3]);
			
			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
		}

		
        //[Test()]
        //public void ConditionalProgramFlow ()
        //{
        //    TextReader programString = File.OpenText("code22.txt");
        //    DefaultSprakRunner program = new DefaultSprakRunner(programString);
        //    program.run();
        //    program.printOutputToConsole();
			
        //    Assert.AreEqual("blå", program.Output[0]);
        //    Assert.AreEqual("lila", program.Output[1]);
        //    Assert.AreEqual("gul", program.Output[2]);
        //    Assert.AreEqual("orange", program.Output[3]);
			
        //    Assert.AreEqual(0, program.getErrorHandler().getErrors().Count);
        //}
		
		[Test()]
		public void NegativeNumbersInExpression ()
		{
			TextReader programString = File.OpenText("code23.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();
			
			Assert.AreEqual("-13.5", program.Output[0]);
			Assert.AreEqual("-6", program.Output[1]);
			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
		}
	
		[Test()]
		public void SimpleFunctionCallInProgram ()
		{
			TextReader programString = File.OpenText("code25.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);

			program.run();
			program.printOutputToConsole();
			
			Assert.AreEqual("42", program.Output[0]);
			Assert.AreEqual(1, program.Output.Count);
			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
		}
		
		[Test()]
		public void FunctionCallReturningValue ()
		{
			TextReader programString = File.OpenText("code26.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
			
			program.run();
			program.printOutputToConsole();
			
			Assert.AreEqual(1, program.Output.Count);
			Assert.AreEqual("500", program.Output[0]);
			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
		}
		
		[Test()]
		public void FunctionCallWithParameters ()
		{
			TextReader programString = File.OpenText("code27.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
			
			program.run();
			program.printOutputToConsole();

            Assert.AreEqual("3", program.Output[0]);
			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
		}
		
		[Test()]
		public void MathFunctions ()
		{
			TextReader programString = File.OpenText("code29.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
			
			program.run();
			program.printOutputToConsole();
			
			Assert.AreEqual("5", program.Output[0]);
			Assert.AreEqual("0.25", program.Output[1]);
			Assert.AreEqual("35", program.Output[2]);
			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
		}

        [Test()]
        public void ProgramThatShouldWorkButDoesnt()
        {
            TextReader programString = File.OpenText("code40.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
        }

        [Test()]
        public void SimpleIFTest()
        {
            TextReader programString = File.OpenText("code42.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
        }		
				
        [Test()]
        public void ChangingVariableValueInSubscope ()
        {
            TextReader programString = File.OpenText("code24.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
			
            Assert.AreEqual("10", program.Output[0]);
            Assert.AreEqual("20", program.Output[1]);
            Assert.AreEqual("0", program.Output[2]);
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
        }	
		
        [Test()]
        public void LoopBasics()
        {
            TextReader programString = File.OpenText("code28.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();

            Assert.AreEqual(10, program.Output.Count);
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(i, Convert.ToInt32(program.Output[i]));
            }
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
        }
		
		[Test()]
        public void RootAprox()
        {
            TextReader programString = File.OpenText("code43.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();
			
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual("3", program.Output[0]);
			Assert.AreEqual("4", program.Output[1]);
        }
		
		[Test()]
        public void EarlyReturn()
        {
            TextReader programString = File.OpenText("code44.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
			
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual("a", program.Output[0]);
			Assert.AreEqual("b", program.Output[1]);
        }
	
        //[Test()]
        //public void ArrayBasics()
        //{
        //    TextReader programString = File.OpenText("code45.txt");
        //    DefaultSprakRunner program = new DefaultSprakRunner(programString);
        //    program.run();
        //    program.getErrorHandler().printErrorsToConsole();
        //    program.printOutputToConsole();
			
        //    Assert.AreEqual(0, program.getErrorHandler().getErrors().Count);
        //    Assert.AreEqual("42", program.Output[0]);
        //}

        [Test()]
        public void CommentedCode()
        {
            TextReader programString = File.OpenText("code46.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();

            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
            Assert.AreEqual("1", program.Output[0]);
            Assert.AreEqual("2", program.Output[1]);
            Assert.AreEqual("3", program.Output[2]);
        }
		
		[Test()]
        public void PlusplusAndMinusminus()
        {
            TextReader programString = File.OpenText("code47.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();

            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
            Assert.AreEqual("11", program.Output[0]);
            Assert.AreEqual("9", program.Output[1]);
        }
		
		[Test()]
        public void Bools()
        {
            TextReader programString = File.OpenText("code48.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();

            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
            Assert.AreEqual("true", program.Output[0]);
            Assert.AreEqual("false", program.Output[1]);
        }
		
		[Test()]
        public void ConcatenateStringAndStuff()
        {
            TextReader programString = File.OpenText("code49.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();

            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
            Assert.AreEqual("Evil: false", program.Output[0]);
            Assert.AreEqual("Age: 42", program.Output[1]);
			Assert.AreEqual("Name: unknown", program.Output[2]);
			Assert.AreEqual("abc6def", program.Output[3]);
        }
		
		[Test()]
        public void SetVariableFromOutsideProgram()
        {		
			s_output = new List<string>();
            TextReader programString = File.OpenText("code50.txt");
			
			// print(MAGIC_NUMBER)
			
			FunctionDefinition[] funcs = new FunctionDefinition[1];
			funcs[0] = new FunctionDefinition("void", 
			                                  "print",
			                                  new string[] { "string" }, 
										      new string[] { "text" }, 
											  new ExternalFunctionCreator.OnFunctionCall(print),
												FunctionDocumentation.Default()
			);
			
			VariableDefinition[] vars = new VariableDefinition[3];
			vars[0] = new VariableDefinition("MAGIC_NUMBER", new ReturnValue(43));
			vars[1] = new VariableDefinition("MAGIC_BOOL", new ReturnValue(true));
			vars[2] = new VariableDefinition("MAGIC_STRING", new ReturnValue("hej"));
			
            SprakRunner program = new SprakRunner(programString, funcs, vars);
			
            program.run();

            Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);
           	Assert.AreEqual("43", s_output[0]);
		 	Assert.AreEqual("true", s_output[1]);
			Assert.AreEqual("hej", s_output[2]);
        }
			          
		static List<string> s_output;
		ReturnValue print(ReturnValue[] args) {
			s_output.Add(Convert.ToString(args[0].ToString()));
			return new ReturnValue();
		}

		[Test()]
        public void ReturnFromMain()
        {
            TextReader programString = File.OpenText("code51.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();

            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
            Assert.AreEqual(0, program.Output.Count);
        }
		
		[Test()]
        public void TryingToBreakOutOfProgram()
        {
            TextReader programString = File.OpenText("code52.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
   
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
            Assert.AreEqual(0, program.Output.Count);
        }
		
		/*
		[Test()]
        public void StrangeTypeConversion()
        {
            TextReader programString = File.OpenText("code53.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
			
            Assert.AreEqual(1, program.getErrorHandler().getErrors().Count);
			Assert.AreEqual(4, program.getErrorHandler().getErrors()[0].getLineNr());
        }
        */
		
		[Test()]
        public void BasicArrayCreation()
        {
            TextReader programString = File.OpenText("code55.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
			
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual("[3, 4, 5, 6]", program.Output[0]);
        }
		
		[Test()]
        public void LoopThroughArray()
        {
            TextReader programString = File.OpenText("code54.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
			
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual("1", program.Output[0]);
			Assert.AreEqual("2", program.Output[1]);
			Assert.AreEqual("3", program.Output[2]);
        }
		
		[Test()]
        public void LoopThroughArray2()
        {
            TextReader programString = File.OpenText("code58.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
			
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual("10", program.Output[0]);
			Assert.AreEqual("11", program.Output[1]);
			Assert.AreEqual("12", program.Output[2]);
			Assert.AreEqual("13", program.Output[3]);
        }
		
		[Test()]
        public void LengthOfArray()
        {
            TextReader programString = File.OpenText("code59.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
			
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual("5", program.Output[0]);
        }
		
		[Test()]
        public void CreateArrayOfNames()
        {
            TextReader programString = File.OpenText("code60.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
			
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual("erik", program.Output[0]);
			Assert.AreEqual("heather", program.Output[1]);
			Assert.AreEqual("johannes", program.Output[2]);
			Assert.AreEqual("niklas", program.Output[3]);
        }
		
		[Test()]
        public void GetSingleElementOutOfArray()
        {
            TextReader programString = File.OpenText("code61.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
			
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual("hello", program.Output[0]);
        }
		
		[Test()]
        public void AssigningToArray()
        {
            TextReader programString = File.OpenText("code62.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
			
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual("abc", program.Output[0]);
			Assert.AreEqual("true", program.Output[1]);
			Assert.AreEqual("false", program.Output[2]);
			Assert.AreEqual("1", program.Output[3]);
			Assert.AreEqual("[1, 2, 3]", program.Output[4]);
        }
		
		[Test()]
        public void ForgettingReturn()
        {
            TextReader programString = File.OpenText("code57.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
			program.getRuntimeErrorHandler().printErrorsToConsole();
			
            Assert.AreEqual(1, program.getRuntimeErrorHandler().getErrors().Count);
        }
		
		[Test()]
        public void ConcatenatingArrays()
        {
            TextReader programString = File.OpenText("code63.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
			program.getCompileTimeErrorHandler().printErrorsToConsole();
			program.getRuntimeErrorHandler().printErrorsToConsole();
			
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual("a: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]", program.Output[0]);
        }
		
		[Test()]
        public void NonStaticArrayAssignment()
        {
            TextReader programString = File.OpenText("code65.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
			program.getCompileTimeErrorHandler().printErrorsToConsole();
			
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual("[5, 6]", program.Output[0]);
        }
		
		[Test()]
        public void MakingSomeListFunctions()
        {
            TextReader programString = File.OpenText("code66.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
			program.getCompileTimeErrorHandler().printErrorsToConsole();
			
            Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual("johannes", program.Output[0]);
			Assert.AreEqual("heather", program.Output[1]);
			Assert.AreEqual("fredag", program.Output[2]);
        }
		
		[Test()]
        public void TooLateVariableDefinition()
        {
            TextReader programString = File.OpenText("code67.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
			program.getRuntimeErrorHandler().printErrorsToConsole();
			
            Assert.AreNotEqual(0, program.getRuntimeErrorHandler().getErrors().Count);
			Assert.AreEqual("hello", program.Output[0]);
        }
		
		[Test()]
        public void CallingFunctionThatDoesNotExist()
        {
            TextReader programString = File.OpenText("code69.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
			program.getCompileTimeErrorHandler().printErrorsToConsole();
			
            Assert.AreEqual(1, program.getCompileTimeErrorHandler().getErrors().Count);
        }
		
		[Test()]
		public void InTheMiddleOfFromToStatement ()
		{
			TextReader programString = File.OpenText("code70.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
			program.getCompileTimeErrorHandler().printErrorsToConsole();
			
            //Assert.AreEqual(1, program.getCompileTimeErrorHandler().getErrors().Count);
		}

		[Test()]
		public void LispyLookingStatement ()
		{
			TextReader programString = File.OpenText("code71.txt");
			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();
			program.printOutputToConsole();
			program.getCompileTimeErrorHandler().printErrorsToConsole();


		}
		
		/*
		[Test()]
        public void AutoDeclareVariable()
        {
            TextReader programString = File.OpenText("code67.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
			program.getErrorHandler().printErrorsToConsole();
			
            Assert.AreEqual(0, program.getErrorHandler().getErrors().Count);
        }
		*/
/*		[Test()]
        public void GetValueFromArray()
        {
            TextReader programString = File.OpenText("code56.txt");
            DefaultSprakRunner program = new DefaultSprakRunner(programString);
            program.run();
            program.printOutputToConsole();
			
            Assert.AreEqual(0, program.getErrorHandler().getErrors().Count);
			Assert.AreEqual("5", program.Output[0]);
        }*/


		
		[Test()]
		public void CallFunctionFromOutside ()
		{
			TextReader programString = File.OpenText("code73.txt");
			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();
			program.printOutputToConsole();
			program.getCompileTimeErrorHandler().printErrorsToConsole();
			ReturnValue result1 = program.RunFunction ("foo", new ReturnValue[] {});
			ReturnValue result2 = program.RunFunction ("bar", new ReturnValue[] {});

			Console.WriteLine ("Result from foo: " + result1.ToString ());
			Console.WriteLine ("Result from bar: " + result2.ToString ());

			Assert.AreEqual (42, (int)result1.NumberValue);
			Assert.AreEqual (127, (int)result2.NumberValue);
		}

		[Test()]
		public void CallFunctionFromOutsideWithArgument ()
		{
			TextReader programString = File.OpenText("code74.txt");
			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();
			program.printOutputToConsole();
			program.getCompileTimeErrorHandler().printErrorsToConsole();

			ReturnValue result = program.RunFunction ("double", new ReturnValue[] { new ReturnValue(40) });
			Console.WriteLine ("Result from double: " + result.ToString ());
			Assert.AreEqual (80, (int)result.NumberValue);
		}

		[Test()]
		public void RemoteFunctionCallShouldNotRunCodeInGlobalScope ()
		{
			TextReader programString = File.OpenText("code84.txt");
			DefaultSprakRunner program = new DefaultSprakRunner(programString);

			//program.run();
			program.printOutputToConsole();
			program.getCompileTimeErrorHandler().printErrorsToConsole();
			
			ReturnValue result = program.RunFunction ("double", new ReturnValue[] { new ReturnValue(32) });

			Console.WriteLine ("Result from double: " + result.ToString ());
			Assert.AreEqual (64, (int)result.NumberValue);

			Assert.AreEqual(1, program.Output.Count);
		}

		[Test()]
		public void ElseIfStatement ()
		{
			TextReader programString = File.OpenText("code76.txt");
			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();
			program.printOutputToConsole();
			program.getCompileTimeErrorHandler().printErrorsToConsole();

			Assert.AreEqual(1, program.Output.Count);
			Assert.AreEqual("yup", program.Output[0]);
		}

		[Test()]
		public void ElseIfStatementInsideFunction ()
		{
			TextReader programString = File.OpenText("code78.txt");
			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.RunFunction("Foo", new ReturnValue[] { new ReturnValue("Left") });

			program.printOutputToConsole();
			program.getCompileTimeErrorHandler().printErrorsToConsole();

			Assert.AreEqual(1, program.Output.Count);
			Assert.AreEqual("l", program.Output[0]);
		}

		[Test()]
		public void DontMissStatementAfterElseIfElse ()
		{
			TextReader programString = File.OpenText("code79.txt");
			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.RunFunction("Foo", new ReturnValue[] { new ReturnValue("Forward") });

			program.printOutputToConsole();
			program.getCompileTimeErrorHandler().printErrorsToConsole();

			Assert.AreEqual(2, program.Output.Count);
			Assert.AreEqual("f", program.Output[0]);
			Assert.AreEqual("buu", program.Output[1]);
		}

		[Test()]
		public void CrashbugWithElseifWithoutEnd ()
		{
			TextReader programString = File.OpenText("code80.txt");
			DefaultSprakRunner program = new DefaultSprakRunner(programString);

			program.run();

			program.printOutputToConsole();
			program.getCompileTimeErrorHandler().printErrorsToConsole();

			Assert.AreEqual(1, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);
		}

		[Test()]
		public void SimpleAndStatements ()
		{
			TextReader programString = File.OpenText("code81.txt");
			DefaultSprakRunner program = new DefaultSprakRunner(programString);

			program.run();

			program.printOutputToConsole();
			program.getCompileTimeErrorHandler().printErrorsToConsole();
			
			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);

			Assert.AreEqual(1, program.Output.Count);
			Assert.AreEqual("yep", program.Output[0]);
		}

		[Test()]
		public void AllowWhitespaceAsCommaInVectors ()
		{
			TextReader programString = File.OpenText("code82.txt");
			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			
			program.run();
			
			program.printOutputToConsole();
			program.getCompileTimeErrorHandler().printErrorsToConsole();
			
			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);
			
			Assert.AreEqual(1, program.Output.Count);
			Assert.AreEqual("b", program.Output[0]);
		}

		[Test()]
		public void AllowWhitespaceAsCommaInFunctionCall ()
		{
			TextReader programString = File.OpenText("code83.txt");
			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			
			program.run();
			
			program.printOutputToConsole();
			program.getCompileTimeErrorHandler().printErrorsToConsole();
			
			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);
			
			Assert.AreEqual(1, program.Output.Count);
			Assert.AreEqual("500", program.Output[0]);
		}

		[Test()]
		public void BinaryOperatorSimpleCase ()
		{
			StringReader programString = new StringReader("var a = 3 + 5 + 6\nprint(a)");

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			Assert.AreEqual("14", program.Output[0]);
			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
		}

		[Test()]
		public void OrOperator ()
		{
			StringReader programString = new StringReader("var x = 2 or 5\nprint(x)");
			
			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();
			
			Assert.AreEqual("true", program.Output[0]);
			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
		}

		[Test()]
		public void OrOperator2 ()
		{
			// TODO: doesn't handle three 'or' statements in a row!

			StringReader programString = new StringReader(
				@"if 2 == 3 or 3 == 4 or 4 == 4
					print(20)
				  else
					print(30)
                  end"
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			Assert.AreEqual("20", program.Output[0]);
			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
		}

		[Test()]
		public void OrOperator3 ()
		{
			StringReader programString = new StringReader(
				@"if false
                    if true
                  	  print(10)
                    end
                  else if 2 == 3 || 3 == 4 || 4 == 4
					print(20)
				  else
					print(30)
                  end"
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			Assert.AreEqual("20", program.Output[0]);
			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
		}

		[Test()]
		public void AndOperator ()
		{
			StringReader programString = new StringReader(
				@"var x = true and true and true
                  var y = true and true and false
                  print(x)
                  print(y)"
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			Assert.AreEqual("true", program.Output[0]);
			Assert.AreEqual("false", program.Output[1]);

			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
		}

		ReturnValue ExternalFunctionCall(ReturnValue[] args) {
			string argsAsText = "id = " + args [0] + ", functionName = " + args [1] + ", args = " + args [2];
			Console.WriteLine("Fake external function call with args " + argsAsText);
			s_output.Add(argsAsText);
			return new ReturnValue();
		}

		[Test()]
		public void DotNotation ()
		{
			s_output = new List<string> ();

			StringReader programString = new StringReader(
				@"var id = 100
                  id.foo(42, true)"
			);

			FunctionDefinition[] funcs = new FunctionDefinition[1];
			funcs[0] = new FunctionDefinition("void", 
				"RemoteFunctionCall",
				new string[] { "number", "string", "array" },
				new string[] { "id", "functionName", "args" }, 
				new ExternalFunctionCreator.OnFunctionCall(ExternalFunctionCall),
				FunctionDocumentation.Default()
			);

			VariableDefinition[] vars = new VariableDefinition[] {};

			SprakRunner program = new SprakRunner(programString, funcs, vars);

			program.run();

			Assert.AreEqual (1, s_output.Count);
			Assert.AreEqual ("id = 100, functionName = foo, args = [42, true]", s_output[0]);
			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
		}

		[Test()]
		public void RemoteFunctionCallWithoutDotNotation ()
		{
			s_output = new List<string> ();

			StringReader programString = new StringReader(
				@"var id = 100
                  RemoteFunctionCall(id, 'foo', [42, true])"
			);

			FunctionDefinition[] funcs = new FunctionDefinition[1];
			funcs[0] = new FunctionDefinition("void", 
				"RemoteFunctionCall",
				new string[] { "number", "string", "array" },
				new string[] { "id", "functionName", "args" }, 
				new ExternalFunctionCreator.OnFunctionCall(ExternalFunctionCall),
				FunctionDocumentation.Default()
			);

			VariableDefinition[] vars = new VariableDefinition[] {};

			SprakRunner program = new SprakRunner(programString, funcs, vars);

			program.run();

			Assert.AreEqual (1, s_output.Count);
			Assert.AreEqual ("id = 100, functionName = foo, args = [42, true]", s_output[0]);
			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
		}

		[Test()]
		public void ComplexDotNotation ()
		{
			s_output = new List<string> ();

			StringReader programString = new StringReader(
				@"var a = 10
                  number inc(number x)
					 return x + 5
                  end
                  (inc(a*a)).foo(inc(1), inc(2), [inc(3), inc(4)])"
			);

			FunctionDefinition[] funcs = new FunctionDefinition[1];
			funcs[0] = new FunctionDefinition("void", 
				"RemoteFunctionCall",
				new string[] { "number", "string", "array" },
				new string[] { "id", "functionName", "args" }, 
				new ExternalFunctionCreator.OnFunctionCall(ExternalFunctionCall),
				FunctionDocumentation.Default()
			);

			VariableDefinition[] vars = new VariableDefinition[] {};

			SprakRunner program = new SprakRunner(programString, funcs, vars);

			program.run();

			Assert.AreEqual (1, s_output.Count);
			Assert.AreEqual ("id = 105, functionName = foo, args = [6, 7, [8, 9]]", s_output[0]);
			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
		}
			
		[Test()]
		public void SimpleArrayPrint ()
		{
			StringReader programString = new StringReader(
				@"var l = [10, 20, 30]
				  print(l)"
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();

			Assert.AreEqual("[10, 20, 30]", program.Output[0]);
			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);
		}

		[Test()]
		public void ArrayWithNumbers ()
		{
			StringReader programString = new StringReader(
				@"array stuff = []
                  stuff[2] = 20
				  stuff[4] = 40
                  stuff['BAM'] = 50
                  stuff[3] = 30
                  stuff[1] = 10
                  print(stuff)"
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();

			Assert.AreEqual("[10, 20, 30, 40, 50]", program.Output[0]);

			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);
		}

		[Test()]
		public void ListWithStringKeys ()
		{
			StringReader programString = new StringReader(
				@"array stuff = []
                  stuff['apa'] = 100
                  stuff['kossa'] = 200
                  stuff['fisk'] = 300
			      stuff[0] = 500
                  stuff[10] = 400                  
                  print(stuff[10])
                  print(stuff['apa'])
                  print(stuff)
                 "
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);

			Assert.AreEqual("400", program.Output[0]);
			Assert.AreEqual("100", program.Output[1]);
		}

		[Test()]
		public void PrintRangeType ()
		{
			StringReader programString = new StringReader(
				@"var xs = from 1 to 1000
                  print(xs)
			      print(from 100 to -50)
                  print(from 10 to 5)
                 "
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual("(from 1 to 1000)", program.Output[0]);
			Assert.AreEqual("(from 100 to -50)", program.Output[1]);
			Assert.AreEqual("[10, 9, 8, 7, 6, 5]", program.Output[2]);

			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);
		}

		[Test()]
		public void UseRangeTypeInLoop ()
		{
			StringReader programString = new StringReader(
				@"number sum = 0
                  loop from 1 to 100
                     sum += @
                  end
                  print(sum)
                  print([1,2,3,4,5,6,7,8,9,1,2,3,4,5,6,7,8,9,1,2,3,4,5,6,7,8,9,1,2,3,4,5,6,7,8,9,1,2,3,4,5,6,7,8,9,1,2,3,4,5,6,7,8,9])
                 "
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);

			Assert.AreEqual("5050", program.Output[0]);
		}

		[Test()]
		public void HugeLoop ()
		{
			StringReader programString = new StringReader(
				@"loop from 1 to 2000
					 print(@)
                  end
                 "
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);

			Assert.AreEqual(2000, program.Output.Count);
		}

		[Test()]
		public void LoopBackwards ()
		{
			StringReader programString = new StringReader(
				@"loop from 200 to 10
					 print(@)
                  end
                 "
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);

			Assert.AreEqual(191, program.Output.Count);
			Assert.AreEqual("200", program.Output[0]);
			Assert.AreEqual("10", program.Output[190]);
		}


		[Test()]
		public void NamedLoopVariable ()
		{
			StringReader programString = new StringReader(
				@"loop a in [10,20,30]
					 print(a)
                  end
                 "
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);

			Assert.AreEqual(3, program.Output.Count);
			Assert.AreEqual("10", program.Output[0]);
			Assert.AreEqual("20", program.Output[1]);
			Assert.AreEqual("30", program.Output[2]);
		}

		[Test()]
		public void NamedLoopVariableWithRange ()
		{
			StringReader programString = new StringReader(
				@"loop a from 10 to 13
					 print(a)
                  end
                 "
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);

			Assert.AreEqual(4, program.Output.Count);
			Assert.AreEqual("10", program.Output[0]);
			Assert.AreEqual("11", program.Output[1]);
			Assert.AreEqual("12", program.Output[2]);
			Assert.AreEqual("13", program.Output[3]);
		}

		[Test()]
		public void NamedLoopVariableTrickySituation ()
		{
			StringReader programString = new StringReader(
				@"var x = [5,6]
                  var y = [7,8]
                  loop x + y
					 print(@)
                  end
                 "
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);

			Assert.AreEqual(4, program.Output.Count);
			Assert.AreEqual("5", program.Output[0]);
			Assert.AreEqual("6", program.Output[1]);
			Assert.AreEqual("7", program.Output[2]);
			Assert.AreEqual("8", program.Output[3]);
		}

		[Test()]
		public void LookupIndexInRange ()
		{
			StringReader programString = new StringReader(
				@"var r = from 10 to 100
                  print(r[0])
                  print(r[90])
                  print(r[91])
                 "
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(1, program.getRuntimeErrorHandler().getErrors().Count);

			Assert.AreEqual(2, program.Output.Count);
			Assert.AreEqual("10", program.Output[0]);
			Assert.AreEqual("100", program.Output[1]);
		}

		[Test()]
		public void SetIndexInRange ()
		{
			StringReader programString = new StringReader(
				@"var r = from 1 to 100
                  print(r)
                  r[0] = 100
                 "
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(1, program.getRuntimeErrorHandler().getErrors().Count);
		}

		[Test()]
		public void CallBuiltInFunctionWithTooFewArgs ()
		{
			StringReader programString = new StringReader(
				@"print()
                 "
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(1, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);
		}


		[Test()]
		public void ErrorMessageWhenMissingEndInIf ()
		{
			StringReader programString = new StringReader(
				@"if true
                      print(42)
                 "
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(1, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);
		}

		[Test()]
		public void ErrorMessageWhenMissingExpressionInIf ()
		{
			StringReader programString = new StringReader(
				@"if 
                      print(42)
                  end
                 "
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(2, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);
		}

		//[Test()]
		public void Profiling ()
		{
			StringReader programString = new StringReader(
				@"void Foo()
                  end
                  
                  Foo()
                  Foo()
                  Foo()
                  Foo()
                  Foo()
                 "
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.Output.Count);

			foreach (var item in program.sprakRunner.GetProfileData()) {
				Console.WriteLine (item.Key + " => " + item.Value);
			}

			Assert.AreEqual(5, program.sprakRunner.GetProfileData()["Foo"].calls);
		}

		[Test()]
		public void DefineFunctionTwice ()
		{
			StringReader programString = new StringReader(
				@"void Foo(number x)
                  end
                  
                  void Foo(number x)
                  end
                 "
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(1, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.Output.Count);
		}

		[Test()]
		public void MissingQuoteInArrayLiteral ()
		{
			StringReader programString = new StringReader(
				@"var a = ['hej', 'pa , 'dig']
                 "
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(1, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.Output.Count);
		}

		[Test()]
		public void DoubleCommaInArrayLiteral ()
		{
			StringReader programString = new StringReader(
				@"var a = ['hej',, 'pa' , 'dig']
                 "
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(1, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.Output.Count);
		}

		[Test()]
		public void MissingEndOfArrayDeclaration ()
		{
			StringReader programString = new StringReader(
				"var a = ['hej',,"
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(1, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.Output.Count);
		}

		[Test()]
		public void MissingArgumentList ()
		{
			StringReader programString = new StringReader(
				"print()"
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(1, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.Output.Count);
		}


		[Test()]
		public void MixedCaseTrueFalse ()
		{
			StringReader programString = new StringReader(
@"if TrUe
    print(10)
  end"
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);
			Assert.AreEqual(1, program.Output.Count);
			Assert.AreEqual("10", program.Output[0]);
		}

		[Test()]
		public void ParseMinusOneAsExpression ()
		{
			StringReader programString = new StringReader(
				@"
var lines = [1,2,3]
var linesCount = 1
print(lines[linesCount-1]) #failes
print(lines[linesCount - 1]) #works
var l1 = (linesCount-1) #failes
var l2 = (linesCount - 1) #works
"
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);
			Assert.AreEqual(2, program.Output.Count);
			Assert.AreEqual("1", program.Output[0]);
			Assert.AreEqual("1", program.Output[1]);
		}

		[Test()]
		public void PlusEqualsInArray ()
		{
			StringReader programString = new StringReader(
				@"
array a = [10,20,30]
a[1] += 5
print(a)
"
			);

			DefaultSprakRunner program = new DefaultSprakRunner(programString);
			program.run();

			program.printOutputToConsole ();
			program.getCompileTimeErrorHandler ().printErrorsToConsole ();
			program.getRuntimeErrorHandler ().printErrorsToConsole ();

			Assert.AreEqual(0, program.getCompileTimeErrorHandler().getErrors().Count);
			Assert.AreEqual(0, program.getRuntimeErrorHandler().getErrors().Count);
			Assert.AreEqual(1, program.Output.Count);
			Assert.AreEqual("[10, 25, 30]", program.Output[0]);
		}
	}
}

