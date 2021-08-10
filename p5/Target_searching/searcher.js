let slider;
class Searcher {
  constructor(x, y) {
    this.pos = createVector(x, y)
    this.vel = createVector(0, 0)
    this.acc = createVector(0, 0)
    this.maxSpeed = 10
    this.maxForce = 0.1
    slider = createSlider(0.1, this.maxSpeed, 2, 0) 
  }

  search(target) {
    let force = p5.Vector.sub(target, this.pos)
    force.setMag(this.maxSpeed)
    force.sub(this.vel)
    force.limit(this.maxForce)
    this.addForce(force)
  }
  
  addForce(force) {
    this.acc.add(force)
  }
  
  update() {
    this.vel.add(this.acc)
    this.pos.add(this.vel)
    this.acc.set(0, 0)
    this.maxSpeed = slider.value()
  }
  
  show() {
    circle(this.pos.x, this.pos.y, 20)
  }
}