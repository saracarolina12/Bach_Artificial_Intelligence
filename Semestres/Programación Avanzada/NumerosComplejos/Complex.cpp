#include "Complex.h"
namespace advanced_programming {
Complex::Complex(): real(0), imaginary(0) {
}
Complex::Complex(double real, double imaginary): real(real), imaginary(imaginary) {
}
Complex::Complex(const Complex &other) {
	real = other.real;
	imaginary = other.imaginary;
}
 Complex operator +(Complex const &c1, Complex const &c2){
    return Complex(c1.getReal()+c2.getReal(), c1.getImaginary()+c2.getImaginary());
}
 Complex operator -(Complex const &c1, Complex const &c2){
    return Complex(c1.getReal()-c2.getReal(), c1.getImaginary()-c2.getImaginary());
}
}
int main(){
    advanced_programming::Complex uno = advanced_programming::Complex(8,2);
    advanced_programming::Complex dos = advanced_programming::Complex(6,6);
    cout<< "a: "<<uno << endl;
    cout<< "b: "<<dos << endl;
    cout<<"a+b: "<<uno+dos<<endl;
    cout<<"b-a: "<<dos-uno<<endl;
    advanced_programming::Complex uno1 = advanced_programming::Complex(10,5);
    advanced_programming::Complex dos1 = advanced_programming::Complex(11,2);
    cout<< "a: "<<uno1 << endl;
    cout<< "b: "<<dos1 << endl;
    cout<<"a+b: "<<uno1+dos1<<endl;
    cout<<"a-b: "<<dos1-uno1<<endl;*/
    return 0;
} 
