import 'package:flutter/material.dart';

void main() => runApp(MyApp());

class MyApp extends StatefulWidget {
  @override
  State<StatefulWidget> createState() {
    return _MyAppState();
  }
}

class _MyAppState extends State<MyApp> {
  Color color = Colors.black;

  @override
  Widget build(BuildContext context) {
    final btnStyle = ElevatedButton.styleFrom(
      shadowColor: Color.fromARGB(255, 7, 0, 51),
      elevation: 3,
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(32.0)),
      minimumSize: Size(100, 40),
      padding: EdgeInsets.symmetric(horizontal: 80, vertical: 20),
    );
    return MaterialApp(
      home: Scaffold(
          backgroundColor: Color.fromARGB(255, 211, 254, 255),
          appBar: AppBar(
            title: Text('Colorful App'),
          ),
          body: Center(
            child:
                Column(mainAxisAlignment: MainAxisAlignment.center, children: [
              Container(
                margin: const EdgeInsets.all(20.0),
                child: Text(
                  'Choose a color:',
                  textAlign: TextAlign.center,
                  overflow: TextOverflow.ellipsis,
                  style: const TextStyle(fontWeight: FontWeight.bold),
                ),
              ),
              Container(
                margin: const EdgeInsets.all(20.0),
                child: ElevatedButton(
                  style: btnStyle,
                  onPressed: () => setState(() {
                    color = Colors.green;
                  }),
                  child: Text("Green"),
                ),
              ),
              Container(
                margin: const EdgeInsets.all(20.0),
                child: ElevatedButton(
                  style: btnStyle,
                  onPressed: () => setState(() {
                    color = Color.fromARGB(255, 0, 77, 140);
                  }),
                  child: Text("Blue"),
                ),
              ),
              Container(
                margin: const EdgeInsets.all(20.0),
                child: ElevatedButton(
                  style: btnStyle,
                  onPressed: () => setState(() {
                    color = Colors.red;
                  }),
                  child: Text("Red"),
                ),
              ),
              Container(
                margin: const EdgeInsets.all(10.0),
                color: color,
                width: 48.0,
                height: 48.0,
              ),
            ]),
          )),
    );
  }
}
