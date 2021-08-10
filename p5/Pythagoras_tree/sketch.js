function setup() {
  createCanvas(400, 250)
}

function draw() {
  background(0)
  noStroke()
  rectMode(CENTER)
  
  let size = 50
  translate(width/2, height - size/2)
  drawSquare(size)
}

const drawSquare = (size) => {
  square(0, 0, size)
  
  if (size > 5) {
    size *= Math.sqrt(2) / 2
    
    push()
    translate(size/2 * 1.4, -size * 1.4)
    rotate(PI / 4)
    drawSquare(size)
    pop()
    
    push()
    translate(-size/2 * 1.4, -size * 1.4)
    rotate(-PI / 4)
    drawSquare(size)
    pop()
  }
}