#include <iostream>
using namespace std;

namespace advanced_programming {
class Complex {
private:
	double real;
	double imaginary;
public:
	Complex();
	Complex(double real, double imaginary);
	Complex(const Complex &other);
	const Complex &operator=(const Complex &other);
	double getReal() const {
		return real;
	}
	double getImaginary() const {
		return imaginary;
	}
    friend ostream& operator<<(ostream &output, const Complex &c){
        //output<<c.getReal()<<"+"<<c.getImaginary()<<"i";
        if(c.getImaginary()<0){
           return output<<c.getReal()<<"-"<<c.getImaginary()<<"i";
        }else{
          return output<<c.getReal()<<"+"<<c.getImaginary()<<"i";
        }
    }
    
};
ostream &operator<<(ostream &out, const Complex &c);
}
