<div align="center">

# JsonTools

**JsonTools** is a blazing fast JSON formatter.

</div>

---

## Usage:

```cmd
  JsonTools [options] [command]

Options:
  --version         Show version information
  -?, -h, --help    Show help and usage information

Commands:
  prettify <originalFile> [newFile]
  minify <originalFile> [newFile]
```

## Example:

> `JsonTools prettify input.json`
- prettify input.json and overwrite the file

> `JsonTools minify input.json output.json`
- minify input.json and save the result to output.json

## Performance:

Tested on a Ryzen 3600, minifying a 403MB json file took ~4.9 seconds.
