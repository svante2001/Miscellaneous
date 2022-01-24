#include <stdio.h>
#include <stdlib.h>

struct element {
    int value;
    struct element *under;
};

struct stack {
    struct element *top;
};

void push (struct stack *s, int v) {
    struct element *e;
    e = (struct element*)malloc(sizeof(struct element));

    if (s->top == NULL) {
        s->top = e;
        e->value = v;
        e->under = NULL;
    } else {
        e->under = s->top;
        s->top = e;
        e->value = v;
    }
}

int pop (struct stack *s) {
    int topElement = s->top->value;
    s->top = s->top->under;
    return topElement;
}

int peek (struct stack *s) {
    return s->top->value;
}

void printStack (struct stack *stack) {
    struct element *i;
    i = stack->top;
    printf("\nStack:\n");
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

    printf("\nPop stack: %i\n", pop(stack));

    printStack(stack);
    
    printf("\nPeek stack: %i\n", peek(stack));
}