int[] A = {5,4,3,2,1};
Console.WriteLine("Unsorted: " + String.Join(",", A));
MergeSort(A, 0, A.Length-1);
Console.WriteLine("Sorted: " + String.Join(",", A));

void MergeSort(int[] A, int p, int r) {
    if (p < r) {
        int q = (p + r) / 2;
        MergeSort(A, p, q);
        MergeSort(A, q + 1, r);
        Merge(A, p, q, r);
    }
}

void Merge(int[] A, int p, int q, int r) {
    int i, j, k;
    int n1 = q - p + 1;
    int n2 = r - q;
    
    int[] L = new int[n1];
    int[] R = new int[n2];
    
    for (i = 0; i < n1; i++) {
        L[i] = A[p + i];
    }

    for (j = 0; j < n2; j++) {
        R[j] = A[q + 1 + j];
    }

    i = 0;
    j = 0;

    for (k = p; k < r; k++) {
        Console.WriteLine(L[i] + "-" + R[j]);

        if (L[i] <= R[j]) {
            A[k] = L[i];
            i++;
        } else {
            A[k] = R[j];
            j++;
        }
    }
}