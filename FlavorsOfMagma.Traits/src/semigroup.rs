pub trait Semigroup {
    fn append(&self, other: &Self) -> Self;

    fn append_into(self, other: Self) -> Self where Self : Sized {
        self.append(&other)
    }
}

impl Semigroup for String {
    fn append(&self, other: &String) -> String {
        let mut s = String::new();
        s.push_str(&self);
        s.push_str(&other);
        s
    }
}