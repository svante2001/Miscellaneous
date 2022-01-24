#include <stdio.h>
#include <stdlib.h>

struct element {
    int value;
    struct element *under;
};

struct stack {
    struct element *top;
};

void push (struct stack *stack, int v) {
    struct element *e;
    e = (struct element*)malloc(sizeof(struct element));

    if (stack->top == NULL) {
        stack->top = e;
        e->value = v;
        e->under = NULL;
    } else {
        e->under = stack->top;
        stack->top = e;
        e->value = v;
    }
}

void printStack (struct stack *stack) {
    struct element *i;
    i = stack->top;
    printf("Stack:\n");
    while (i != NULL) {
        printf("%d ", i->value);
        i = i->under;
    }
    printf("\n");
}

int main() {
    struct stack *stack;
    stack = (struct stack*)malloc(sizeof(struct stack));
    stack->top = NULL;

    push(stack, 2);
    push(stack, 4);
    push(stack, 16);
    printStack(stack);
}