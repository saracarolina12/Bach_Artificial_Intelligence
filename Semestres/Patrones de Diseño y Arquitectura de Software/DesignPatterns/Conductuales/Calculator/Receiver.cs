using System;

namespace Calculator
{
	public class Receiver
	{
        public void receive_data(int a, int b, char op){
            if(op == '+') sum(a, b);
            if(op == '-') sub(a, b);
            if(op == '/') div(a, b);
            if(op == '*') mul(a, b);
        }
        public float sum(int a, int b){
            return a + b;
        }
        public float sub(int a, int b){
            return a - b;
        }
        public float div(int a, int b){
            return a / b;
        }
        public float mul(int a, int b){
            return a * b;
        }
	}
}