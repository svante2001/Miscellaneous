import Data.List
import System.IO

fib 0 = 0
fib 1 = 1
fib n = fib (n-1) + fib(n-2)

fac 0 = 1
fac n = fac (n-1) * n

isPalindrome l = do
    l == reverse l

compress l = do
    map head (group l)

encode l = do
    map (\x -> (head x, length x)) (group l)

data Item a = Single a | Multiple Int a
    deriving Show

encodeModified l = do
    map (\x -> (
            if (length x) == 1 then
                Single (head x)
            else
                Multiple (length x) (head x)
        ))
        (group l)

decode []                    = []
decode ((Single x) : xs)     = x : decode xs
decode ((Multiple 2 x) : xs) = x : x : decode xs
decode ((Multiple n x) : xs) = x : decode ((Multiple (n-1) x) : xs)

dupli [] = []
dupli (x:xs) = x : x : dupli xs

repli l n = do
    foldl (\x acc -> x ++ acc) "" (map (\y -> replicate n y) l)

split l n = do
    splitAt n l

slice l n m = do
    fst (splitAt (m-n+1) (snd (splitAt (n-1) l)))

removeAt n l = do
    (fst (splitAt (n-1) l)) ++ (drop n l)