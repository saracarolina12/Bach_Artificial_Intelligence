import cv2
import numpy as np

#rangos de colores
veintelow= np.array([90,50,50])
veinteup= np.array([130,255,255])

cincuentalow= np.array([140,50,50])
cincuentaup= np.array([180,255,255])

cienlow= np.array([0,50,50])
cienup= np.array([35,255,255])

doscientoslow= np.array([30,0,0])
doscientosup= np.array([80,255,255])

color = ""

def funcion(img):
  gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
  gray = cv2.GaussianBlur(gray, (5, 5), 0)

  ret, imgt = cv2.threshold(gray, 127, 255, cv2.THRESH_BINARY_INV)

  #cv2.imshow("Image threshold", imgt)
  countours, hierarchy = cv2.findContours(imgt.copy(), cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
  rectangles = [cv2.boundingRect(countour) for countour in countours]
  #print(rectangles)
  c = 0
  for rect in rectangles:
    if rect[2] > 30 and rect[3] > 30:
      imgn = img[rect[1]:rect[1] + rect[3], rect[0]:rect[0] + rect[2]]
      imgn = cv2.resize(imgn, (100, 50))
      c += 1
      
      # Clasificar la imagen imgn
      # Escribir el resultado
      
      #20
      BGR_RGB = cv2.cvtColor(imgn, cv2.COLOR_BGR2RGB) #convertir color [viene en cv]
      hsv = cv2.cvtColor(BGR_RGB,cv2.COLOR_RGB2HSV)
      maskrange20 = cv2.inRange(hsv,veintelow,veinteup) 
      img_maskA = cv2.bitwise_and(BGR_RGB, BGR_RGB, mask=maskrange20)
      
      #50
      BGR_RGB = cv2.cvtColor(imgn, cv2.COLOR_BGR2RGB) #convertir color [viene en cv]
      hsv = cv2.cvtColor(BGR_RGB,cv2.COLOR_RGB2HSV)
      maskrange50 = cv2.inRange(hsv,cincuentalow,cincuentaup) 
      img_maskB = cv2.bitwise_and(BGR_RGB, BGR_RGB, mask=maskrange50)
      
      nrows, ncols, nch = imgn.shape
      
      Ximg = np.reshape(imgn,(nrows*ncols,3))
      Xhsv = np.reshape(hsv,(nrows*ncols,3))
      nsample = 20
      idx = np.random.permutation(nrows*ncols)[:nsample] #toma los primeros 300 pixeles de forma random
      Ximg = Ximg[idx,:]
      Xhsv = Xhsv[idx,:]
      
      
      tocompare = np.array([ Xhsv[0,0] ,Xhsv[0,1], Xhsv[0,2] ])
      #print("hsv: ", Xhsv[0,0])
      #tocompare = np.array([150,50,50])
      #'''
      if((tocompare >= veintelow).all() and (tocompare <= veinteup).all()):
          color = "20"
      elif((tocompare >= cincuentalow).all() and (tocompare <= cincuentaup).all() ):
          color="50"
      else: color=""
      print("\nveintelow:", veintelow)
      print("hsv: ", tocompare)
      cv2.imshow("Image rect",  imgn)
      

      cv2.rectangle(img, (rect[0], rect[1]), (rect[0] + rect[2], rect[1] + rect[3]), (255, 0, 0), 2)
      cv2.putText(img, color, (rect[0], rect[1]), cv2.FONT_HERSHEY_SIMPLEX, 1, (200, 0, 0), 3, cv2.LINE_AA)
  return img

'''
cam = cv2.VideoCapture(0)
while True:
    val, img = cam.read()
    img = funcion(img)
    cv2.imshow("Image funcion",img)
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break
cam.release()
cv2.destroyAllWindows()

'''
captura = cv2.VideoCapture('billetes.mp4')
while (captura.isOpened()):
  ret, img = captura.read()

  img = funcion(img)

  if ret == True:
    cv2.imshow('video', img)
    if cv2.waitKey(1) & 0xFF == ord('q'):
      break
  else:
    break
captura.release()
cv2.destroyAllWindows()
