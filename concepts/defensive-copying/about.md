Imagine you have a code-base of several hundred thousand lines. You are passed the dictionary of developers into some method you are developing. Perhaps you have been tasked with printing out details of privileged developers. You decide to blank out the eye color in the dictionary to protect the developers' privacy. Unless a [deep copy][so-deep-copy] of the dictionary was made in the `Authenticator.GetDevelopers()` method, or, even better, it was wrapped in a read-only collection then you will have just trashed the authenticator.

This follows the principle of [defensive copying][defensive-copying]. You can make sure your formal API is not circumvented by avoiding exposure to callers of internal writeable state.

[so-deep-copy]: https://stackoverflow.com/questions/78536/deep-cloning-objects
[defensive-copying]: https://www.informit.com/articles/article.aspx?p=31551&seqNum=2
