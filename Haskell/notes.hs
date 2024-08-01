import Data.List
import System.IO
import Distribution.PackageDescription.Configuration (addBuildableCondition)
import GHC.Float (asinDouble)

{-
    Ninety-Nine Haskell Problems
    https://wiki.haskell.org/H-99:_Ninety-Nine_Haskell_Problems
-}

-- Problem 6 
isPalindrome l = do
    l == reverse l

-- Problem 8
compress l = do
    map head (group l)

-- Problem 10
encode l = do
    map (\x -> (head x, length x)) (group l)

-- Problem 11
data Item a = Single a | Multiple Int a
    deriving Show

encodeModified l = do
    map (\x -> (
            if length x == 1 then
                Single (head x)
            else
                Multiple (length x) (head x)
        ))
        (group l)

-- Problem 12
decode []                    = []
decode ((Single x) : xs)     = x : decode xs
decode ((Multiple 2 x) : xs) = x : x : decode xs
decode ((Multiple n x) : xs) = x : decode (Multiple (n-1) x : xs)

-- Problem 14
dupli [] = []
dupli (x:xs) = x : x : dupli xs

-- Problem 15
repli l n = do
    concatMap (replicate n) l

-- Problem 17
split l n = do
    splitAt n l

-- Problem 18
slice l n m = do
    take (m - n + 1) ( drop (n - 1) l)

-- Problem 20
removeAt n l = do
    take (n - 1) l ++ drop n l

-- Problem 21
insertAt i l n = do
    take n l ++ i ++ drop n l

-- Problem 22
range n m = [n..m] 

