//Invert Tree: DFS(stack)
TreeNode invertTree(TreeNode* root){
	if(!root) return NULL;
    stack<TreeNode*> s;
    s.push(root);

    while(!s.empty()){
        TreeNode* temp = s.top();
        s.pop();
        if(temp){
            s.push(temp->left);
            s.push(temp->right);
            swap(temp->left, temp->right);
        }
    }
    return root;
}