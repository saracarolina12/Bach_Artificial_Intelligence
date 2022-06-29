//DFS
void dfs(TreeNode* root){
	if(!root) return;
	cout<<root->value<<endl;
	dfs(root->left);
	dfs(root->right);
}