#include <stdio.h>

struct element {
    int value;
    struct element *under;
};

struct stack {
    struct element *top;
};

// TODO: 


void printStack (struct stack *stack) {
    struct element *i;
    i = stack->top;
    while (i != NULL) {
        printf("%d ", i->value);
        i = i->under;
    }
}

int main() {
    struct stack *stack;
    stack = (struct stack*)malloc(sizeof(struct stack));
    stack->top = NULL;

    // push(stack, 1);
    // push(stack, 2);

    printStack(stack);
}