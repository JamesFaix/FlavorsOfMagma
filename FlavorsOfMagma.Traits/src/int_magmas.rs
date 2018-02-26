use super::semigroup::*;

impl Semigroup for i32 {
    fn append(&self, other: &i32) -> i32 {
        self + other
    }
}

#[derive(PartialEq, Eq, Debug)]
pub struct IntAdd(i32);

impl IntAdd {
    pub fn new(n: i32) -> IntAdd {
        IntAdd {
            0: n
        }
    }

    pub fn value(&self) -> i32 {
        self.0
    }
}

#[derive(PartialEq, Eq, Debug)]
pub struct IntMultiply(i32);

impl IntMultiply {
    pub fn new(n: i32) -> IntMultiply {
        IntMultiply {
            0: n
        }
    }
    
    pub fn value(&self) -> i32 {
        self.0
    }
}

impl Semigroup for IntAdd {
    fn append(&self, other: &IntAdd) -> IntAdd {
        IntAdd(self.0 + other.0)
    }
}

impl Semigroup for IntMultiply {
    fn append(&self, other: &IntMultiply) -> IntMultiply {
        IntMultiply(self.0 * other.0)
    }
}