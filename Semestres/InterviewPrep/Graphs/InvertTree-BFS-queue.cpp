//Invert Tree: BFS(queue)
TreeNode invertTree(TreeNode* root){
	if(!root) return NULL;
	queue<TreeNode*> q;
	q.push(root);
	
	while(!q.empty()){
		TreeNode* temp = q.front();
		q.pop();
		if(temp){
			q.push(temp->left);
			q.push(temp->right);
			TreeNode* temp = n->left;
            n->left = n->right;
            n->right = temp;
		}
	}
	return root;
}