# Summary

Good commit messages are important for maintaining a clear and concise history of changes to a project. They help other contributors understand what changes have been made and why, and they make it easier to revert changes if necessary. To help ensure that our commit history is as useful as possible, we have established the following guidelines for writing commit messages. Please follow these guidelines when committing changes to our project. If you have any questions, don't hesitate to ask the project maintainers.

Please observe the following guidelines for your commits:
- The first line represents the subject of the commit.
- The body of the commit messages must be separated from the subject by a blank line.
- Lines should not exceed 72 characters.
- When naming other developers in a patch, use their full name instead of nickname.

Many git tools assume these metrics for proper rendering, such as `git log --pretty=oneline` or `gitweb`. Automated reports or just plain future development depend on good logs.

- Do not embed images in the commit description.
- Aim for atomic commits: each commit should do one thing only. Similarly, a pull request should aim to fix one bug or implement one new feature. It should only contain multiple commits if that is required to fix the bug or implement the feature.

## :globe_with_meridians: Language

- Commit messages should use American English suitable for technical documentation.
- Abbreviations should only be used when they are well understood in the field.
- ASCII for diagrams and arrows can be used where appropriate.
- Use real names to refer to people, not usernames.

## :card_file_box: Commit Types

Nearly all commits are one of the following types and must follow the associated conventions.

### :bug: Bug Fixes
- Don't copy the bug report name verbatim if it's not descriptive, explain what the problem was.
- Explain what you fixed on a user level, do not focus only on what was wrong in the code.
- Start the commit log with `:bug:Fix T12345:` or `:bug:Fix:` (for unreported bugs), so it's immediately clear that it's a bug fix.

**Example:**
```
:bug:Fix T12345: single short line to explain on a user level what the bug was

Optionally, more user level information about which scenarions the bug happened
in, why it was fixed in this particular way, etc.

If non-obvious, some technical note about what the cause of the bug was and how
it was solved.
```

### :tada: New Features and Improvements
- Explain what the feature does on a user level, not just the code changes.
- Keep user level explanation and code changes explanation separate.
- If it's not obvious, explain what the feature is useful for or when it should be used.
- Start with a project category like: `RNG:`, or `Text:`.
- Use the :sparkles: (`:sparkles:`) gitmoji when this commit adds a new feature.
- Use the :zap: (`:zap:`) gitmoji when this commit improves the performance of an existing feature.

**Example:**
```
<intention_gitmoji>Category: single short line saying what the feature you have implemented is.

More user level information about how this feature works, explanation about why it's good to have,
link to docs or release notes, etc.

Optional short technical notes about how this feature was implemented.
```

### 🛠️ Code Cleanups and Refactoring
- Make it clear when there are no functional changes.
- Separate cleanup commits from functional changes. First clean up the code, commit that as a cleanup commit, then commit the functional changes.
- Start the subject line with `Cleanup:` or `Refactor:` (for bigger changes).
- Use the :coffin: (`:coffin:`) gitmoji when removing dead or deprecated code (this is part of the cleanup process).
- Use the 🚨 (`:rotating_light:`) gitmoji when fixing compiler/linter warnings (this is part of the cleanup process).
- Use the 🩹 (`:adhesive_bandage:`) gitmoji when making small changes.
- Use the ♻️ (`:recycle:`) gitmoji whem refactoring major changes.

**Example:**
```
<intention_gitmoji>Type: Single short line describing what you cleaned up

Optionally more information about the cleanup.

No functional changes.
```

### :safety_vest: Chores
- Explain what the chore is on a user level, not just code changes.
- Make it clear when there are no functional changes.
- Separate chore commits. For each chore, commit that as a chore commit, then perform another chore and commit again.
- Start the subject line with `Structure:`, `Docs:`, `CI:`, `Dependency:`, `Config:`, `Logs:`, or `Literal:`.
- Use the 🎨(`:art:`) gitmoji when improving the structure or format of the code.
- Use the 🚚(`:truck:`) gitmoji when moving or renaming resources (e.g.: files, paths, routes).
- Use the 📝(`:memo:`) gitmoji when adding or updating documentation.
- Use the 💚(`:green_heart:`) gitmoji when fixing a CI build.
- Use the ⬇️(`:arrow_down:`) gitmoji when downgrading a dependency.
- Use the ⬆️(`:arrow_up:`) gitmoji when upgrading a dependency.
- Use the 📌(`:pushpin:`) gitmoji when pining a dependency to a specific version.
- Use the ➕(`:heavy_plus_sign:`) gitmoji when adding a dependency.
- Use the ➖(`:heavy_minus_sign:`) gitmoji when removing a dependency.
- Use the 🔊(`:loud_sound:`) gitmoji when adding or updating logs.
- Use the 🔇(`:mute:`) gitmoji when removing logs.
- Use the 💬(`:speech_balloon:`) gitmoji when adding or updating text and literals.

**Example:**
```
<intention_gitmoji>Chore: Single short line describing the chore being performed.

Optionally more information about the chore.

No functional changes.
```

### :construction_worker: Maintenance
- Explain what you are maintaining in the project.
- Maintenance tasks usually do not involve functional changes.
- Separate maintenance commits. Each maintenance task should have its own commit.
- Start the subject line with the `Maintenance:` tag.
- Use the 👽(`:alien:`) gitmoji when updating code due to external API changes.
- Use the 🔐(`:closed_lock_with_key:`) gitmoji when adding or updating secrets.
- Use the 👷(`:construction_worker:`) gitmoji when adding or updating the CI build scripts.
- Use the 🔨(`:hammer:`) gitmoji when adding or updating development scripts.
- Use the 🔧(`:wrench:`) gitmoji when adding or updating configuration files.
- Use the 📄(`:page_facing_up:`) gitmoji when adding or updating the project's license.
- Use the 👥(`:busts_in_silhouette:`) gitmoji when adding or updating project contributors.
- Use the 🩺(`:stethoscope:`) gitmoji when adding or updating healthchecks.
- Use the 💸(`:money_with_wings:`) gitmoji when adding sponsors.

**Example:**
```
<intention_gitmoji>Maintenance: Single short line describing the chore being performed.

Optionally more information about what the maintenance task is about.
```

## :mag_right: Code Review

If you are commiting a patch that went through code review, the following live should be added at the end.

**Example:**

```
Reviewed By: someone
```

This will close the revision and give us a standard way to indicate who reviewed the code.

## :black_nib: Author / Committer

- If you commit a patch of your own, you are author and committer of the commit (the default).
- If you commit a patch on behalf of someone else, there are two cases:
  - If the full name if the original author is known, you are committer, but the original author becomes author in git. Commit as git commit --author "Full Name <Nick>".
  - Otherwise, you remain author and committer in git. However, you have to add `Contributed by @nick` to the commit message. 
