import 'package:comidas_mundiales/category_meals_screen.dart';
import 'package:flutter/material.dart';
import 'categories_screen.dart';

void main() => runApp(const MyApp());

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Comidas',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      // home: CategoriesScreen(),
      initialRoute: '/',
      routes: {
        '/': (context) => const CategoriesScreen(),
        '/category-meals': (context) => const CategoryMealsScreen(),
      },
    );
  }
}
