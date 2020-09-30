package com.itminds.graph;

public class CustomerNode {
    private String person;
    private CustomerNode next;

    public CustomerNode(CustomerNode next, String person) {
        this.next = next;
        this.person = person;
    }

    public CustomerNode getNext() {
        return next;
    }

    public String getPerson() {
        return person;
    }

    public CustomerNode previous(String person) {
        return new CustomerNode(this, person);
    }

    public static CustomerNode create(String person) {
        return new CustomerNode(null, person);
    }
}
