// Used GCC

#include <stdio.h>
#include <stdlib.h>

struct element {
    int value;
    struct element *next;
};

struct list {
    struct element *head;
};

void printList(struct list *list) {
    struct element *ci;
    ci = list->head;
    while(ci != NULL) {
        printf("%d ", ci->value);
        ci = ci->next;
    }
    printf("\n");
}

void push(struct list *list, int value) {
    struct element *e;
    e = (struct element*)malloc(sizeof(struct element));
    e->value = value;
    e->next = NULL;
    if (list->head == NULL) {
        list->head = e;
    } else {
        struct element *ci;
        ci = list->head;
        while(ci->next != NULL) {
            ci = ci->next;
        }
        ci->next = e;
    }
}

int length (struct list *list) {
    int length = 0;
    struct element *ci;
    ci = list->head;
    while(ci != NULL) {
        length++;
        ci = ci->next;
    }
    return length;
}

void insert(struct list *list, int index, int value) {
    // out of bounds for list
    int l = length(list);
    if (index < 0 || l < index-1) {
        printf("Insert: Out of bunds for list\n");
        return;
    }

    // insert at the beginning of list
    if (list->head == NULL || index == 0) {
        struct element *n;
        n = (struct element*)malloc(sizeof(struct element));
        n->value = value;
        n->next = list->head;
        list->head = n;
        return;
    }

    // insert at the middle of list
    if (index > 0 || index < l) {
        struct element *n;
        n = (struct element*)malloc(sizeof(struct element));
        struct element *itr = list->head;
        n->value = value;
        int jndex = 0;
        while(jndex < index-1) {
            itr = itr->next;
            jndex++;
        }
        n->next = itr->next;
        itr->next = n;
        return;
    }
}

struct element* searchForDelete(struct list *list, int key) {
    struct element *x = list->head;
    struct element *prev = x;
    while (x != NULL && (x->value) != key) {
        prev = x;
        x = x->next;
    }
    return prev;
}

void delete(struct list *list, int key) {
    if (list->head == NULL) {
        return;
    }
    // Delete head
    if (list->head->value == key) {
        list->head = list->head->next;
    } else {
        struct element *p = searchForDelete(list, key);
        p->next = p->next->next;
    }
}

int main() {
    struct list *list;
    list = (struct list*)malloc(sizeof(struct list));
    list->head = NULL;

    // initialize list
    push(list, 5);
    push(list, 15);

    // insert in beginning, mid and end to test
    insert(list, 0, 0);
    insert(list, 2, 10);
    insert(list, 4, 20);

    printList(list);
    printf("Length of list: %d\n", length(list));


    // delete from the list
    printf("\nDeleting elements\n");
    delete(list, 5);
    printList(list);
    printf("Length of list: %d\n", length(list));
}