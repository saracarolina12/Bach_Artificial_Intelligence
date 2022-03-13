#include<bits/stdc++.h>
using namespace std;
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
void addWord(int nodeID, string word, int pos){
  if(pos == word.length()) return;
  int k = Trie[nodeID].ref[word[pos]-'a'];
  if(k == -1){
    k = Trie.size();
    Trie[nodeID].ref[word[pos]-'a'] = k;
    Trie.push_back(TrieNode());
  }
  Trie[k].isWord = (pos == word.length()-1) || Trie[k].isWord? true: false;
  addWord(k, word, pos + 1);
}
bool search(int nodeID, string word, int pos){
  if(pos == word.length()) return Trie[nodeID].isWord;
  int k = Trie[nodeID].ref[word[pos]-'a'];
  if(k == -1) return 0;
  return search(k, word, pos + 1);
}
unordered_set<string> s;
int main(){
  Trie.push_back(TrieNode());
  int n, m;
  cin>>n>>m;
  string tosearch="";
  for(int i=0; i<n; i++){
  	cin>>tosearch;
  	addWord(0,tosearch, 0);
	s.insert(tosearch);
  }
  for(int i=0; i<m; i++){
    cin >> tosearch;
    if(search(0, tosearch, 0) == 1) cout<<"YES"<<endl;
    else cout<<"NO"<<endl;
  }
  return 0;
}