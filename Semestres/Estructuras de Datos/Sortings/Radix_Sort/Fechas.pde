class Fecha {
  int dia, mes, anio;
  
  Fecha()
  {
    this.anio = (int)random(1950, 2020+1);
    this.mes = (int)random(1, 12+1);
    this.dia = (int)random(1, diaXmes(this.mes)+1);
  }

  private int diaXmes(int m)
  {
    if (m==1 || m==3 || m==5 || m==7 || m==8 || m==10 ||m==12) return 31;
    else if (m==4 || m==6 || m==9 || m==11) return 30;
    else if (m==2) return 28;
    else return 0;
  }


  public String toString()
  {
    return dia + "/" + mes2string(mes) + "/" + anio + "\n";
  }
  

  private String mes2string(int m) 
  {
    if (m==1) return "Enero";
    else if (m==2) return "Febrero";
    else if (m==3) return "Marzo";
    else if (m==4) return "Abril";
    else if (m==5) return "Mayo";
    else if (m==6) return "Junio";
    else if (m==7) return "Julio";
    else if (m==8) return "Agosto";
    else if (m==9) return "Septiembre";
    else if (m==10) return "Octubre";
    else if (m==11) return "Noviembre";
    else if (m==12) return "Diciembre";
    else return "ERORR";
  }

  public int parte(int s) 
  {
    if (s ==1) return dia%10;//unidad del dia
    else if (s ==2) return dia/10; //decena del día
    else if (s ==3)return mes%10; //unidad del mes
    else if (s==4)return mes/10; //decena del mes
    else if (s==5) return anio%10;//unidad del año
    else if (s==6) return (anio/10)%10;//decena del año
    else if (s==7) return (anio/100)%10;//centena del año
    else if (s==8) return anio/1000;//millar del año
    else return 0;
  }
}
