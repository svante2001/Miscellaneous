#include <stdio.h>
#include <stdlib.h>

struct element {
    int value;
    struct element *next;
};

struct queue {
    struct element *first;
};

struct element* lastElement (struct queue *q) {
    struct element *i;
    i = q->first;
    while (i->next != NULL) {
        i = i->next;
    }
    return i;
}

void enqueue (struct queue *q, int v) {
    struct element *e;
    e = (struct element*)malloc(sizeof(struct element));
    
    if (q->first == NULL) {
        q->first = e;
        e->value = v;
        e->next = NULL;
    } else {
        struct element *l = lastElement(q);
        l->next = e;
        e->value = v;
        e->next = NULL;
    }
}

int dequeue (struct queue *q) {
    int r = q->first->value;
    q->first = q->first->next;
    return r;
}

void printQueue (struct queue *q) {
    struct element *i;
    i = q->first;
    printf("\nQueue:\n");
    while (i != NULL) {
        printf("%d ", i->value);
        i = i->next;
    }
    printf("\n");
}

int main() {
    struct queue *queue;
    queue = (struct queue*)malloc(sizeof(struct queue));
    queue->first = NULL; 

    enqueue(queue, 2);
    enqueue(queue, 4);
    enqueue(queue, 16);

    printQueue(queue);

    printf("\nDequeue: %i\n", dequeue(queue));

    printQueue(queue);
}