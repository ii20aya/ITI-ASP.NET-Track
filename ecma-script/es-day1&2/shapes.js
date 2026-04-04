export class Shape {
    constructor() {
        if (this.constructor === Shape) throw new Error("Cannot instantiate abstract class");
    }
    calculateArea() {}
    calculateParameter() {}
    
    toString() {
        return `Area: ${this.calculateArea()}, Parameter: ${this.calculateParameter()}`;
    }
}

export class Rectangle extends Shape {
    constructor(w, h) {
        super();
        this.w = w;
        this.h = h;
    }
    calculateArea() { return this.w * this.h; }
    calculateParameter() { return 2 * (this.w + this.h); }
}

export class Square extends Rectangle {
    constructor(side) {
        super(side, side);
    }
}

export class Circle extends Shape {
    constructor(r) {
        super();
        this.r = r;
    }
    calculateArea() { return Math.PI * this.r * this.r; }
    calculateParameter() { return 2 * Math.PI * this.r; }
}