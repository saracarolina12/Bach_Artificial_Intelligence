/*
  //Buscar palabras en diccionario
    O(mn)
     Características:
      *Cada nodo representa una palabra o un prefijo
      *El primer nodo está vacío, representa un string vacío
*/

  //Código base
  
  //Clase Trie
    class TrieNode{
    public:
      bool isWord;
      vector<int> ref;
      TrieNode(bool isWord = 0){
        this -> isWord = isWord;
        ref = vector<int>(26, -1);
      }
    }; 
    vector<TrieNode> Trie;
    void addWord(int nodeID, string word, int pos);
    bool search(int nodeID, string word, int pos);
