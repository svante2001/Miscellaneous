// Mergesort (CLRS) using sentinel values.
// This implementation does not merge correctly.

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
    int leftIndex, rightIndex;
    int n1 = q - p + 1;
    int n2 = r - q + 1;
    
    int[] L = new int[n1];
    int[] R = new int[n2];
    
    for (int i = 0; i < n1; i++) {
        L[i] = A[p + i];
    }

    for (int i = 0; i < n2; i++) {
        R[i] = A[q + i];
    }

    leftIndex = 0;
    rightIndex = 0;

    L[L.Length-1] = int.MaxValue;
    R[R.Length-1] = int.MaxValue;

    for (int i = p; i < r; i++) {
        if (L[leftIndex] <= R[rightIndex]) {
            A[i] = L[leftIndex++];
        } else {
            A[i] = R[rightIndex++];
        }
    }
}