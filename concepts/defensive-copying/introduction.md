# Introduction

In security sensitive situations (or even simply on a large code-base where developers have different priorities and agendas) you should avoid allowing a class's public API to be circumvented by accepting and storing a method's mutable parameters or by exposing a mutable member of a class through a return value or as an `out` parameter.
