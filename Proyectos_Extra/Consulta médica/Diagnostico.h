#include<bits/stdc++.h>
using namespace std;
void diagnostico(string ,string , double ,double ,double ,double , int,int);
ofstream write;
ifstream read;
vector<bool> v;
class Persona{
    public:
        string nombre, apellido, sexo, ayuno;
        double estatura, peso, glucosa, temperatura;
        int presion,edad;
        Persona();
        Persona(string, string,string, double, double, double, double, int,string);
        double IMC(double, double);
        string escala_termica(double);
        string por_peso(double, double);
        friend ostream &operator<<(ostream &out, Persona &P){
            out<<P.escala_termica(P.temperatura)<<"\n"<<P.por_peso(P.estatura,P.peso)<<"\n";
            return out;
        }
        friend istream& operator>>(istream &in, Persona &P){
            in>>P.nombre>>P.apellido>>P.sexo>>P.estatura>>P.peso>>P.glucosa>>P.temperatura>>P.presion>>P.ayuno;
            return in;
        }
};
Persona::Persona(){};
Persona::Persona(string _nombre, string _apellido, string _sexo, double _estatura, double _peso, double _glucosa, double _temperatura, int _presion, string _ayuno){
    nombre = _nombre;
    apellido = _apellido;
    sexo = _sexo;
    estatura = _estatura;
    peso = _peso;
    glucosa = _glucosa;
    temperatura = _temperatura;
    presion = _presion;
    ayuno = _ayuno;
}
void escala_termica(double temp){
    string s="";
    if(temp <= 35.0) s=  "\t*Hipotermia ligera", v.push_back(1);
    else if((temp > 35 && temp <=37.5)) s="\t*Temperatura normal";
    else if (temp>37.5 && temp<=39.5) s="\t*Fiebre", v.push_back(1);
    else if(temp>=39.5 && temp<=41) s="\t*Fiebre alta", v.push_back(1);
    else if (temp>41) s="\t*Hiperpirexia", v.push_back(1);
    write<<s<<endl;
}

double IMC(double est, double peso){
    double imc=0;
    imc = peso/(pow(est,2));
    return imc;
}

void por_peso(double est, double peso){
    double imc = IMC(est, peso);
    string s="";
    if(imc <= 18.5) s = "\t*Bajo peso", v.push_back(1);
    else if (imc>=18.5 && imc<25) s="\t*Peso normal";
    else if (imc>=25 && imc<30) s="\t*Sobrepeso", v.push_back(1);
    else if (imc>=30 && imc<35) s="\t*Obesidad", v.push_back(1);
    else if (imc>=35 && imc<40) s="\t*Obesidad grado 2", v.push_back(1);
    else if (imc>=40) s="\t*Obesidad grado 3", v.push_back(1);
    write<<s<<endl;
}

void niveles_gluc(double glu,string ayuno){
    string s="";
    if(ayuno=="ayuno"){
        if(glu>=70 && glu<=100) s= "\t*Sin diabetes";
        else if(glu>=100 && glu<=125) s= "\t*Pre-diabetes", v.push_back(1);
        else if(glu>=126) s= "\t*Diabetes", v.push_back(1);
    }else{
        if(glu<=140) s="\tSin diabetes";
        else if(glu>=140 && glu<=199) s="\t*Pre-diabetes", v.push_back(1);
        else if(glu>=200) s="\t*Diabetes", v.push_back(1);
    }
    write<<s<<endl;
}

void tension_arterial(string sexo, int pres, int edad){
    string h="hombre", m="mujer",s="";
    if(edad>=16 && edad<=18){
        if(sexo==h){
            if(pres>=105 && pres<=135) s = "\t\t  Presión sistólica";
            else if(pres>=60 && pres<=86) s= "\t\t  Presión diastólica";
        }
        else if(sexo==m){
            if(pres>=100 && pres<=130) s = "\t\t  Presión sistólica";
            else if(pres>=60 && pres<=85) s= "\t\t  Presión diastólica";
        }
    }
    else if(edad>=19 && edad<=24){
        if(sexo==h){
            if(pres>=105 && pres<=139) s = "\t\t  Presión sistólica";
            else if(pres>=62 && pres<=88) s= "\t\t  Presión diastólica";
        }
        else if(sexo==m){
            if(pres>=100 && pres<=130) s = "\t\t  Presión sistólica";
            else if(pres>=60 && pres<=85) s= "\t\t  Presión diastólica";
        }
    }
    else if(edad>=25 && edad<=29){
        if(sexo==h){
            if(pres>=108 && pres<=139) s = "\t\t  Presión sistólica";
            else if(pres>=65 && pres<=89) s= "\t\t  Presión diastólica";
        }
        else if(sexo==m){
            if(pres>=102 && pres<=135) s = "\t\t  Presión sistólica";
            else if(pres>=60 && pres<=86) s= "\t\t  Presión diastólica";
        }
    }
    else if(edad>=30 && edad<=39){
        if(sexo==h){
            if(pres>=110 && pres<=145) s = "\t\t  Presión sistólica";
            else if(pres>=68 && pres<=92) s= "\t\t  Presión diastólica";
        }
        else if(sexo==m){
            if(pres>=105 && pres<=139) s = "\t\t  Presión sistólica";
            else if(pres>=65 && pres<=89) s= "\t\t  Presión diastólica";
        }
    }
    else if(edad>=40 && edad<=49){
        if(sexo==h){
            if(pres>=110 && pres<=150) s = "\t\t  Presión sistólica";
            else if(pres>=70 && pres<=96) s= "\t\t  Presión diastólica";
        }
        else if(sexo==m){
            if(pres>=105 && pres<=150) s = "\t\t  Presión sistólica";
            else if(pres>=65 && pres<=96) s= "\t\t  Presión diastólica";
        }
    }
    else if(edad>=50 && edad<=59){
        if(sexo==h){
            if(pres>=115 && pres<=155) s = "\t\t  Presión sistólica";
            else if(pres>=70 && pres<=98) s= "\t\t  Presión diastólica";
        }
        else if(sexo==m){
            if(pres>=110 && pres<=155) s = "\t\t  Presión sistólica";
            else if(pres>=70 && pres<=98) s= "\t\t  Presión diastólica";
        }
    }
    else if(edad>=60){
        if(sexo==h){
            if(pres>=115 && pres<=160) s = "\t\t  Presión sistólica";
            else if(pres>=70 && pres<=100) s= "\t\t  Presión diastólica";
        }
        else if(sexo==m){
            if(pres>=115 && pres<=160) s = "\t\t  Presión sistólica";
            else if(pres>=70 && pres<=100) s= "Presión diastólica";
        }
    }
    write<<" ~Su presión es:\n"<<s<<endl;
}

void diagnostico(string sexo,string ayuno, double est,double peso,double glu,double temp, int pres, int edad){
    escala_termica(temp);
    por_peso(est,peso);
    niveles_gluc(glu,ayuno);
    tension_arterial(sexo,pres,edad);
}


