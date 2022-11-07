import "package:flutter/material.dart";

void main() => runApp(MyApp());

class MyApp extends StatelessWidget {
  var questionIndex = 0;

  @override
  Widget build(BuildContext context) {
    var questions = [
      'What\'s your favorite color?',
      'What\'s your favorite animal?'
    ];
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(
          title: Text('My First App'),
        ),
        body: Column(children: [
          Text(questions[questionIndex]),
          ElevatedButton(
              onPressed: () => print('Answer 1'), child: Text('Answer 1')),
        ]),
      ),
    );
  }
}
