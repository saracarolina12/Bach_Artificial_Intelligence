//voltea la imagen utilizando bmp
import java.util.*;
import java.io.File;
import java.io.*;
import java.io.RandomAccessFile;

public class E14p2{
  public static void main(String[] args){
    if (args.length==0){
      System.out.printf("\nPor favor, indique el nombre del archivo como argumento.\n");
      return;
    }
    try{
      int n=Integer.parseInt(args[0]);
      int n1=n*n;
      if ((Math.sqrt(n)%2)==0){
        DataOutputStream out=new DataOutputStream(new FileOutputStream("Salida.bmp"));
        System.out.printf("%d", n);

        out.writeChar((int)0x424D);
        out.writeInt(conv((n1)*24));

        out.writeInt(0);

        out.writeInt(conv((int)0x36));
        out.writeInt(conv((int)0x28));

        out.writeInt(conv(n)); 
        out.writeInt(conv(n)); 

        out.writeChar(conv2((int)0x01));
        out.writeChar(conv2((int)0x18)); 

        out.writeInt(0);
        out.writeInt(conv(n1));

        out.writeInt(conv((int)0x0EC4));
        out.writeInt(conv((int)0x0EC4));

        out.writeInt(0);
        out.writeInt(0);


        for (int i=1; i<=n; i++)
        {
          if (i%2==0)
          {
            for (int j=1; j<=n; j++)
            {
              if (j%2==0)
              {
                out.write(0xFF);
                out.write(0xFF);
                out.write(0xFF);
              } else
              {
                out.write(0x00);
                out.write(0x00);
                out.write(0x00);
              }
            }
          } else
          {
            for (int j=1; j<=n; j++)
            {
              if (j%2!=0)
              {
                out.write(0xFF);
                out.write(0xFF);
                out.write(0xFF);
              } else
              {
                out.write(0x00);
                out.write(0x00);
                out.write(0x00);
              }
            }
          }
        }
      } else
      {
        System.out.printf("Solo pontencias de dos");
      }
    }
    catch(Exception e)
    {
      System.out.printf("\nError\n");
    }
  }

    public static int conv2(int i)
  {
    return((i&0xff)<<8)+((i>>8)&0xff);
  }

  public static int conv(int i)
  {
    return((i&0xff)<<24)+((i&0xff00)<<8)+((i&0xff0000)>>8)+((i>>24)&0xff);
  }  
}
