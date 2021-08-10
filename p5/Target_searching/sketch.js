let searcher
function setup() {
  createCanvas(400, 400)
  searcher = new Searcher(100, 100)
  target = createVector(width/2, height/2)
}

function draw() {
  background(0)
  
  // Skud ud til buur for det her if statement haha.
  if (abs(searcher.pos.x - target.x) <= 20 && abs(searcher.pos.y - target.y) <= 20) {
    target = createVector(random(80, width-80), random(80, height-80))
  }
  
  fill("blue")
  circle(target.x, target.y, 20)
  fill("white")
  
  searcher.search(target)
  
  searcher.update()
  searcher.show()
} 