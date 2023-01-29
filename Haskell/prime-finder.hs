isPrime :: Int -> Int
isPrime n = do
  if length [nums | nums <- [2..n], n `mod` nums == 0] == 1 then
    n
  else
    0

main = do
  print (filter (0 /=) (map isPrime [1,2..100]))
  
