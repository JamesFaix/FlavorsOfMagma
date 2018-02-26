#[cfg(test)]
mod tests {
    use super::super::semigroup::*;
    use super::super::int_magmas::*;

    #[test]
    fn string_append_is_associative() {
        let a = "Hello".to_string();
        let b = " world".to_string();
        let c = "!".to_string();

        assert_eq!(
            a.append(&b).append(&c),
            a.append(&b.append(&c))
        );
    }

    #[test]
    fn int_append_is_associative() {
        let a = 3;
        let b = 5;
        let c = 7;

        assert_eq!(
            a.append(&b).append(&c),
            a.append(&b.append(&c))
        );
    }

    #[test]
    fn intAdd_append_is_associative() {
        let a = IntAdd::new(3);
        let b = IntAdd::new(5);
        let c = IntAdd::new(7);

        assert_eq!(
            a.append(&b).append(&c),
            a.append(&b.append(&c))
        );
    }
    
    #[test]
    fn intMultiply_append_is_associative() {
        let a = IntMultiply::new(3);
        let b = IntMultiply::new(5);
        let c = IntMultiply::new(7);

        assert_eq!(
            a.append(&b).append(&c),
            a.append(&b.append(&c))
        );
    }

    #[test]
    fn intMultiply_distributes_over_intAdd() {
        let a = 2;
        let b = 3;
        let c = 4;

        let addB = IntAdd::new(b);
        let addC = IntAdd::new(c);

        let multA = IntMultiply::new(a);
        let multB = IntMultiply::new(b);
        let multC = IntMultiply::new(c);

        assert_eq!(
            multA.append(&IntMultiply::new(addB.append(&addC).value())).value(), //a * (b + c)
            IntAdd::new(multA.append(&multB).value()).append(&IntAdd::new(multA.append(&multC).value())).value() // (a * b) + (a * c)
        );
    }
}