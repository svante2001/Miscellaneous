#include <stdio.h>
#include <stdlib.h>

#define spacing 10

struct node {
  int value;
  struct node *left;
  struct node *right;
  struct node *parent;
};

struct tree {
  struct node *root;
};

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

int treeMinimum(struct tree *tree) {
  struct node *n = tree->root;
  while (n->left != NULL) {
    n = n->left;
  }
  return n->value;
}

int treeMaximum(struct tree *tree) {
  struct node *n = tree->root;
  while (n->right != NULL) {
    n = n->right;
  }
  return n->value;
}

int main() {
  struct tree *tree;
  tree = (struct tree*)malloc(sizeof(struct tree));
  tree->root = NULL;

  insert(tree, 10);
  insert(tree, 5);
  insert(tree, 15);
  insert(tree, 2);
  insert(tree, 7);
  insert(tree, 25);
  
  printTree(tree);

  printf("\nMinimum: %d\n", treeMinimum(tree));
  printf("Maximum: %d\n", treeMaximum(tree));
}
