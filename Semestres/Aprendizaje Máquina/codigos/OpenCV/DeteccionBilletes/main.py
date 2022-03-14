import cv2
import numpy as np

#rangos de colores
veintelow= np.array([90,0,0])
veinteup= np.array([130,255,255])

cincuentalow= np.array([140,0,100])
cincuentaup= np.array([180,100,255])

cienlow= np.array([0,0,0])
cienup= np.array([35,255,255])

doscientoslow= np.array([30,0,0])
doscientosup= np.array([80,255,255])

def funcion(img):
  gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
  gray = cv2.GaussianBlur(gray, (5, 5), 0)

  ret, imgt = cv2.threshold(gray, 127, 255, cv2.THRESH_BINARY_INV)

  cv2.imshow("Image threshold", imgt)
  countours, hierarchy = cv2.findContours(imgt.copy(), cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
  rectangles = [cv2.boundingRect(countour) for countour in countours]
  #print(rectangles)
  c = 0
  for rect in rectangles:
    if rect[2] > 300 and rect[3] > 300:
      imgn = img[rect[1]:rect[1] + rect[3], rect[0]:rect[0] + rect[2]]
      #imgn = cv2.resize(imgn, (100, 100))
      c += 1
      

      # Clasificar la imagen imgn
      # Escribir el resultado
      BGR_RGB = cv2.cvtColor(imgn, cv2.COLOR_BGR2RGB) #convertir color [viene en cv]
      hsv = cv2.cvtColor(BGR_RGB,cv2.COLOR_RGB2HSV)
      maskrange20 = cv2.inRange(hsv,doscientoslow,doscientosup) #detectamos máscara (los que sí son azules los pone de blanco (sí cumplen))
      img_mask = cv2.bitwise_and(BGR_RGB, BGR_RGB, mask=maskrange20)
      
      cv2.imshow("Image rect",  img_mask)
      
      color = ""
      

      cv2.rectangle(img, (rect[0], rect[1]), (rect[0] + rect[2], rect[1] + rect[3]), (255, 0, 0), 2)
      cv2.putText(img, 'hola', (rect[0], rect[1]), cv2.FONT_HERSHEY_SIMPLEX, 1, (200, 0, 0), 3, cv2.LINE_AA)
  return img

cam = cv2.VideoCapture(0)
while True:
    val, img = cam.read()
    img = funcion(img)
    cv2.imshow("Image funcion",img)
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break
cam.release()
cv2.destroyAllWindows()