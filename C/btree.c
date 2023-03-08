#include <stdio.h>
#include <stdlib.h>

#define spacing 5

struct node {
  int value;
  struct node *left;
  struct node *right;
  struct node *parent;
};

struct tree {
  struct node *root;
};

// This is bad since no dealloc..
struct tree* subTree(struct node *node) {
  struct tree *t;
  t = (struct tree*)malloc(sizeof(struct tree));
  t->root = node;
  return t;
}

void printTreeRec(struct node *root, int space) {  
  if (root == NULL) {
    return;
  }
  
  space += spacing;
 
  printTreeRec(root->right, space);
 
  printf("\n");
  for (int i = spacing; i < space; i++) {
     printf(" ");
  }
  printf("%d\n", root->value);
 
  printTreeRec(root->left, space);
}

void printTree(struct tree *tree) {
  printTreeRec(tree->root, 0);
}

void insert(struct tree *tree, int value) {
  struct node *x = tree->root;
  
  struct node *y;
  y = (struct node*)malloc(sizeof(struct node));
  
  struct node *z;
  z = (struct node*)malloc(sizeof(struct node));
  z->value = value;
 
  while (x != NULL) {
    y = x;
    if (z->value < x->value) {
      x = x->left;
    }
    else {
      x = x->right;
    }
  }
  z->parent = y;

  // Not sure why i can't say x == NULL here..?
  if (tree->root == NULL) {
    tree->root = z;
  }
  else if (z->value < y->value) {
    y->left = z;
  }
  else {
    y->right = z;
  }	 
}

struct node* treeMinimum(struct tree *tree) {
  struct node *n = tree->root;
  while (n->left != NULL) {
    n = n->left;
  }
  return n;
}

struct node* treeMaximum(struct tree *tree) {
  struct node *n = tree->root;
  while (n->right != NULL) {
    n = n->right;
  }
  return n;
}

struct node* treeSearchRec(struct node *node, int key) {
  if (node == NULL || key == node->value) {
    return node;
  }
  if (key < node->value) {
    return treeSearchRec(node->left, key);
  }
  else {
    return treeSearchRec(node->right, key);
  }
}

struct node* successor(struct node *node) {
  if (node->right != NULL) {
    return treeMinimum(subTree(node));
  }
  struct node* y;
  y = node->parent;
  while(y != NULL && node == y->right) {
    node = y;
    y = y->right;
  }
  return y;
} 

struct node* predecessor(struct node *node) {
  if (node->left != NULL) {
    return treeMaximum(subTree(node));
  }
  struct node* y;
  y = node->right;
  while(y != NULL && node == y->left) {
    node = y;
    y = y->left;
  }
  return y;
}

int main () {
  struct tree *tree;
  tree = (struct tree*)malloc(sizeof(struct tree));
  tree->root = NULL;  

  insert(tree, 10);
  insert(tree, 15);
  insert(tree, 5);
  insert(tree, 2);
  insert(tree, 7);
  
  printTree(tree);

  printf("\nMinimum: %d\n", treeMinimum(tree)->value);
  printf("Maximum: %d\n", treeMaximum(tree)->value);
  printf("%d's successor: %d\n",   (tree->root->left->value), successor(tree->root->left)->value);
  printf("%d's predecessor: %d\n", (tree->root->left->value), predecessor(tree->root->left)->value);

}
