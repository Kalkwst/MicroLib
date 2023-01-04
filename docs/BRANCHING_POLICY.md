Welcome to our project! We use GitHub flow as our branching model, which means that all development takes place in branches and pull requests are used to merge code into the main branch (usually called "master"). This allows us to review and discuss code changes before they are merged, ensuring that our codebase stays clean and maintainable. In this document, we will explain the details of our branching policy and how to use GitHub flow to contribute to our project. Please take a few minutes to read through this document before getting started. If you have any questions, don't hesitate to reach out to the project maintainers.

## What is the GitHub Flow?
So, what is the GitHub Flow?
- Anything in the `master` branch is deployable.
- To work on something new, create a descriptively named branch off of `master` (you can find guidelines on branch naming later in the document).
- Commit to that branch locally and regularly push your work to the same named branch on the server. Review our [Commit Style Guide]() so you can create commits that follow the project's guidelines.
- When you need feedback or help, or you think that the branch is ready for merging, open a pull request.
- After someone else has reviewed and signed off on the feature, you can merge it into `master`.
- Once it is merged and pushed to `master` you can and *should* delete your branch on local and on remote.

So, let's take a look at each of these steps.

### Anything in the master branch is deployable

This is basically the only hard _rule_ of the system. There is only one branch that has any specific and consistent meaning and we named it `master`. t's incredibly rare that this gets rewound (the branch is moved back to an older commit to revert work) - if there is an issue, commits will be reverted or new commits will be introduced that fixes the issue, but the branch itself is almost never rolled back.

The `master` branch is stable and it is always, always safe to deploy from it or create new branches off of it. If you push something to master that is not tested or breaks the build, you break the social contract of the development team and you normally feel pretty bad about it. Every branch we push has tests run on it so if you haven't run them locally, you can simply push to a topic branch (even a branch with a single commit) on the server and wait for the tests to pass.

### Create descriptive branches off of master

When you want to start work on anything, you create a descriptively named branch off of the stable `master` branch. This has several advantages - one is that when you fetch, you can see the topics that everyone else has been working on. Another is that if you abandon a branch for a while and go back to it later, it's fairly easy to remember what it was.

This is nice because when we go to the GitHub branch list page we can easily see what branches have been worked on recently and roughly how much work they have on them.

As a rule of thumb, there are three types of branches: `feature`, `bugfix`,  and `maintenance` branches. Each of this type of branch has a specific role in the repository.

- **Feature branches**: **Feature branches are almost anything you can think of.** If you need to write a chunk of code, you’ll use a feature branch. Feature branches follow the name convention: `feature/project/name`. All feature branches should start with the `feature` prefix. Then you need to specify the project you are working in, e.g., `Text`, `RNG`, `LINQ` or `JSON`. Finally, add a descriptive name on what your feature is all about.
- **Bugfix branches**: **Bugfix branches are connected with bugs reported in the issue page**. Bugfix branches follow the name convention: `bugfix/issue_number`. All bugfix branches should start with the `bugfix` prefix. Then you need to specify the number of the issue related to the bug.
- **Maintenance branches:** **Maintenance branches are used almost always by the project maintainerts**. These branches are used for various maintenance jobs needed in the project, such as updating the CI scripts. Maintenance branches follow the naming convention: `maintenance/name`. All maintenance branches start with the `maintenance` prefix. Then add a descriptive name on what the maintenance tasks entail.

This is nice because when we go to the GitHub branch list page we can easily see what branches have been worked on recently and roughly how much work they have on them.

### Push to named branches constantly

Another big difference from git-flow is that we push to named branches on the server constantly. Since the only thing we really have to worry about is `master` from a deployment standpoint, pushing to the server doesn't mess anyone up or confuse things - everything that is not `master` is simply something being worked on.

It also make sure that our work is always backed up in case of laptop loss or hard drive failure. More importantly, it puts everyone in constant communication. A simple 'git fetch' will basically give you a TODO list of what everyone is currently working on.

It also lets everyone see, by looking at the GitHub Branch List page, what everyone else is working on so we can see if they want help with something.

### Open a pull request at any time

GitHub has an amazing code review system called [Pull Requests](http://help.github.com/send-pull-requests/). Many people use it for open source work - fork a project, update the project, send a pull request to the maintainer. However, it can also easily be used as an internal code review system, which is what we do.

If you are stuck in the progress of your feature or branch and need help or advice, you open a pull request. You can cc people in the GitHub system by adding in a [@username](https://github.com/username), so if you want the review or feedback of specific people, you simply cc them in the PR message.

This is cool because the Pull Request feature let's you comment on individual lines in the unified diff, on single commits or on the pull request itself and pulls everything inline to a single conversation view. It also let you continue to push to the branch, so if someone comments that you forgot to do something or there is a bug in the code, you can fix it and push to the branch, GitHub will show the new commits in the conversation view and you can keep iterating on a branch like that.

If the branch has been open for too long and you feel it's getting out of sync with the master branch, you can merge master into your topic branch and keep going. You can easily see in the pull request discussion or commit list when the branch was last brought up to date with the `master`.

When everything is really and truly done on the branch and you feel it's ready to deploy, you can move on to the next step.

### Merge only after pull request review

We don't simply do work directly on `master` or work on a topic branch and merge it in when we think it's done.

Once we get that, and the branch passes CI, we can merge it into master for deployment, which will automatically close the Pull Request when we push it.

## Conclusion

We hope that this document has helped you understand our branching policy and how to use GitHub flow to contribute to our project. By following these guidelines, you can help us ensure that our codebase stays clean, maintainable, and easy to work with. We appreciate your contributions and look forward to working with you! If you have any questions or need help, don't hesitate to reach out to the project maintainers. Thank you for your interest in our project!
